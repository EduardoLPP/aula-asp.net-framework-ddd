using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using NOTION.Dominio.Interfaces.IUnidadeDeTrabalho;
using NOTION.Dominio.Interfaces.Repositorios;
using NOTION.Infra.Data.Basicos.Atributos;
using NOTION.Infra.Data.Contexto;
using NOTION.Infra.Data.Repositorios;

namespace NOTION.Infra.Data.UnidadeDeTrabalho
{
    public class NotionUnidadeDeTrabalho : IUnidadeDeTrabalho
    {

        private DbContext Contexto { get; set; }

        private DbContextTransaction Transacao { get; set; }

        private Dictionary<string, object> DicionarioDeRepositorios { get; set; }

        public NotionUnidadeDeTrabalho(NotionContexto context)
        {
            this.Contexto = context;
        }

        public IRepositorio<T> ObtenhaRepositorio<T>() where T : class
        {
            if(this.DicionarioDeRepositorios == null)
                this.DicionarioDeRepositorios = new Dictionary<string, object>();

            var tipo  = typeof(T);

            if (!this.DicionarioDeRepositorios.ContainsKey(tipo.Name))
            {
                var assembly = Assembly.GetExecutingAssembly();

                foreach(var tclass in assembly.GetTypes())
                {
                    if(tclass.GetCustomAttribute(typeof(AtributoDeRepositorioImplementado), false) != null)
                    {
                        AtributoDeRepositorioImplementado repo = (AtributoDeRepositorioImplementado)Attribute
                            .GetCustomAttribute(tclass, typeof(AtributoDeRepositorioImplementado));

                            if (repo.TipoBase == tipo)
                            {
                            object repoInstance = Activator.CreateInstance(tclass, this.Contexto);
                            this.DicionarioDeRepositorios.Add(tipo.Name, repoInstance);
                            }
                    }
                }
            }

            if (!this.DicionarioDeRepositorios.ContainsKey(tipo.Name))
            {
                var repositorioGenerico = new Repositorio<T>(this.Contexto);
                this.DicionarioDeRepositorios.Add(tipo.Name, repositorioGenerico);
            }

            return DicionarioDeRepositorios[tipo.Name] as IRepositorio<T>;
        }

        public TRepo ObtenhaRepositorio<T, TRepo>()
            where T : class
            where TRepo : class
        {
           return this.ObtenhaRepositorio<T>() as TRepo;
        }

        public int SalveAlteracoes()
        {
            return this.Contexto.SaveChanges();
        }

        public void InicieTransacao()
        {
            this.Transacao = this.Contexto.Database.BeginTransaction();

        }

        public void FinalizeTransacao()
        {
            this.Transacao.Commit(); 
        }
        public void RevertaTransacao()
        {
            this.Transacao.Rollback();
        }

        public void Dispose()
        {
            if(this.Transacao != null)
            {
                this.Transacao.Dispose();
            }

            if (this.Contexto != null)
            {
                this.Contexto.Dispose();
            }
        }

      
    }
}

