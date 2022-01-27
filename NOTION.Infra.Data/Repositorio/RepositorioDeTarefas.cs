using NOTION.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Infra.Data.Repositorio
{
    public class RepositorioDeTarefas : Repositorio<Tarefa>
    {

        public IEnumerable<Tarefa> ObtenhaTarefasComplexas()
        {
            throw new System.NotImplementedException();
        }
    }
}
