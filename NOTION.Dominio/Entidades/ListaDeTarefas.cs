using System;
using System.Collections.Generic;

namespace NOTION.Dominio.Entidades
{
    public class ListaDeTarefas
    {
        public Guid Id { get; set; }
        public virtual List<Tarefa> Tarefas { get; set; }
        public string Descricao { get; set; }
    }
}
