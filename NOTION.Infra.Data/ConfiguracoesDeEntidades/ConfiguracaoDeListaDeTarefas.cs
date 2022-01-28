using NOTION.Dominio.Entidades;
using System.Data.Entity.ModelConfiguration;


namespace NOTION.Infra.Data.ConfiguracoesDeEntidades
{
    public class ConfiguracaoDeListaDeTarefas : EntityTypeConfiguration<ListaDeTarefas>
    {
        public ConfiguracaoDeListaDeTarefas()
        {
            HasKey(listaDeTarefas => listaDeTarefas.Id);

            Property(listaDeTarefas => listaDeTarefas.Descricao).IsRequired();

            HasMany(listaDeTarefas => listaDeTarefas.Tarefas);
            HasMany(listaDeTarefas => listaDeTarefas.Tarefas)
                .WithRequired()
                .HasForeignKey(tarefa => tarefa.IdListaDeTarefas);
        }
    }
}
