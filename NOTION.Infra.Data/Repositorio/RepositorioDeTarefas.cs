using NOTION.Dominio.Entidades;
using NOTION.Dominio.Interfaces.Repositorios;
using NOTION.Infra.Data.Basicos.Atributos;
using System.Collections.Generic;
using System.Data.Entity;

namespace NOTION.Infra.Data.Repositorios
{
    [AtributoDeRepositorioImplementado(typeof(Tarefa))]
    public class RepositorioDeTarefas : Repositorio<Tarefa>, IRepositorioDeTarefas
    {
        public RepositorioDeTarefas(DbContext contexto) : base(contexto)
        {
        }

        public override IEnumerable<Tarefa> Obtenha()
        {
            const string sql = "SELECT * FROM TAREFAS ORDER BY ATUALIZADOEM DESC";

            return base.Contexto.Set<Tarefa>().SqlQuery(sql);
        }

        public IEnumerable<Tarefa> ObtenhaTarefasComplexas()
        {
            const string sql = "SELECT * FROM TAREFAS WHERE TIPOTAREFA = 1 ORDER BY ATUALIZADOEM DESC";

            return base.Contexto.Set<Tarefa>().SqlQuery(sql);
        }
    }
}
