using NOTION.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Infra.Data.ConfiguracoesDeEntidades
{
    public class ConfiguracaoDeTarefas : EntityTypeConfiguration<Tarefa>
    {
        public ConfiguracaoDeTarefas()
        {
            HasKey(tarefa => tarefa.Id);

            Property(tarefa => tarefa.IdListaDeTarefas).IsRequired();
            Property(tarefa => tarefa.Descricao).IsRequired();
            Property(tarefa => tarefa.TipoTarefa).IsRequired();
            Property(tarefa => tarefa.CriadoEm).IsRequired();
            Property(tarefa => tarefa.AtualizadoEm).IsRequired();
        }

    }
}
