using NOTION.Dominio.Basicos;
using System;

namespace NOTION.Dominio.Entidades
{
     public class Tarefa
    {
        public Guid Id { get; set; }
        public Guid ListaDeTarefas { get; set; }
        public EnumeradorTipoTarefa TipoTarefa { get; set; }
        public string Descricao { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AtualizadoEm { get; set; }


    }
}
