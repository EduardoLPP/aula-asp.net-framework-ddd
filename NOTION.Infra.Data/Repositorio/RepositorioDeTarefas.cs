using NOTION.Dominio.Entidades;
using NOTION.Dominio.Interfaces.Repositorios;
using NOTION.Infra.Data.Basicos.Atributos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Infra.Data.Repositorio
{
    [AtributoDeRepositorioImplementado(typeof(Tarefa))]
    public class RepositorioDeTarefas : Repositorio<Tarefa>, IRepositorioDeTarefas
    {
        public RepositorioDeTarefas(DbContext contexto) : base(contexto)
        {
        }

        public override IEnumerable<Tarefa> Obtenha()
        {
            const string sql = "SELECT * FROM TAREFA";

            return base.Contexto.Set<Tarefa>().SqlQuery(sql);
        }

        public IEnumerable<Tarefa> ObtenhaTarefasComplexas()
        {
            const  string sql = "SELECT * FROM TAREFA  WHERE TIPOTAREFA = 1";

            return base.Contexto.Set<Tarefa>().SqlQuery(sql);
        }
    }
}
