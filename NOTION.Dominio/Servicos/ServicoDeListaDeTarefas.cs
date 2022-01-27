using NOTION.Dominio.Entidades;
using NOTION.Dominio.Interfaces.IUnidadeDeTrabalho;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace NOTION.Dominio.Servicos
{
    public class ServicoDeListaDeTarefas : Servico
    {
        public ServicoDeListaDeTarefas(IUnidadeDeTrabalho unidadeDeTrabalho) : base(unidadeDeTrabalho)
        {
        }

        public List<ListaDeTarefas> ObtenhaTodasAsListas()
        {
            var repositorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<ListaDeTarefas>();
            return repositorio.Obtenha().ToList();
        }

        public ListaDeTarefas ObtenhaListaDeTarefas(Guid id)
        {
            var repositorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<ListaDeTarefas>();
            return repositorio.Obtenha(id);
        }

        public void AdcioneListaDeTarefas(string descricao)
        {
            var lista = new ListaDeTarefas();
            lista.Id = Guid.NewGuid();
            lista.Descricao = descricao;

            var repositiorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<ListaDeTarefas>();
            repositiorio.Adcione(lista);
        }

        public void AtualizeListaDeTarefas(Guid id, string descricao)
        {
            var lista = this.ObtenhaListaDeTarefas(id);
            lista.Descricao = descricao;

            var repositiorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<ListaDeTarefas>();
            repositiorio.Atualize(lista);

            base.UnidadeDeTrabalho.SalveAlteracoes();
        }

        public void RemovaListaDeTarefas(Guid id)
        {
            var lista = this.ObtenhaListaDeTarefas(id);
            var repositiorio = base.UnidadeDeTrabalho.ObtenhaRepositorio<ListaDeTarefas>();
            repositiorio.Atualize(lista);

            base.UnidadeDeTrabalho.SalveAlteracoes();
        }
    }
}
