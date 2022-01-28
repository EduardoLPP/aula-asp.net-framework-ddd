using NOTION.Dominio.Basicos;
using NOTION.Dominio.Entidades;
using NOTION.Dominio.Interfaces.IUnidadeDeTrabalho;
using NOTION.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Dominio.Servicos
{
    public class ServicoDeTarefa : Servico
    {
        public ServicoDeTarefa( IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }

        public Tarefa ObtenhaTarefa(Guid id)
        {
            var repositorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<Tarefa>();
            return repositorio.Obtenha(id);
        }

        public List<Tarefa> ObtenhaTarefaComplexas()
        {
            var repositorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<Tarefa, IRepositorioDeTarefas>();
            return repositorio.ObtenhaTarefasComplexas().ToList();
        }

        public void Adcione(Guid idListaDeTarefas, string descricao, EnumeradorTipoTarefa tipo)
        {
            var tarefa = new Tarefa();
            tarefa.Id = Guid.NewGuid();
            tarefa.IdListaDeTarefas = idListaDeTarefas;
            tarefa.Descricao = descricao;
            tarefa.TipoTarefa = tipo;

            var repositorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<Tarefa>();
            repositorio.Adcione(tarefa);

            base.UnidadeDeTrabalho.SalveAlteracoes();
        }

        public void Atualize( Guid id, string descricao, EnumeradorTipoTarefa tipo)
        {
            var tarefa = this.ObtenhaTarefa(id);
            tarefa.Descricao = descricao;
            tarefa.TipoTarefa = tipo;

            var repositorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<Tarefa>();
            repositorio.Atualize(tarefa);

            base.UnidadeDeTrabalho.SalveAlteracoes();
        }

        public void Remova(Guid id)
        {
            var tarefa = this.ObtenhaTarefa(id);

            var repositorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<Tarefa>();
            repositorio.Remova(tarefa);

            base.UnidadeDeTrabalho.SalveAlteracoes();
        }

    }
}
