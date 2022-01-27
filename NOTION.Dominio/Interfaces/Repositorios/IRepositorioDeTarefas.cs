using NOTION.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Dominio.Interfaces.Repositorios
{
    public interface IRepositorioDeTarefas : IRepositorio<Tarefa>
    {
        IEnumerable<Tarefa> ObtenhaTarefasComplexas();
    }
}
