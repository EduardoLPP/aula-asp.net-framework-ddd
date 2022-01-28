using NOTION.Infra.Data.ConfiguracoesDeEntidades;
using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;


namespace NOTION.Infra.Data.Contexto
{
    public class NotionContexto : DbContext
    {
        public NotionContexto() : base("NotionContexto")
        {     
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            modelBuilder.Properties<string>()
                .Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>()
                .Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new ConfiguracaoDeListaDeTarefas());
            modelBuilder.Configurations.Add(new ConfiguracaoDeTarefas());

        }

        public override int SaveChanges()
        {
            foreach(var entry in ChangeTracker.Entries().Where(entry => 
            entry.Entity.GetType().GetProperty("CriadoEm") != null ||
            entry.Entity.GetType().GetProperty("AtualizadoEm") != null))
            {
                if(entry.State == EntityState.Added)
                {
                    entry.Property("CriadoEm").CurrentValue = DateTime.Now;
                    entry.Property("AtualizadoEm").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("CriadoEm").IsModified = false;
                    entry.Property("AtualizadoEm").CurrentValue = DateTime.Now;
                }
            }

            return SaveChanges();
        }
    }
}
