using System.Data.Entity;

namespace NOTION.Infra.Data
{
    public class NotionContexto : DbContext
    {
        public NotionContexto() : base("NotionContexto")
        { 
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
        }

    }
