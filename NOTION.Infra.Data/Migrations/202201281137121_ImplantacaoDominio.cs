namespace NOTION.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ImplantacaoDominio : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListaDeTarefas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tarefas",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdListaDeTarefas = c.Guid(nullable: false),
                        TipoTarefa = c.Int(nullable: false),
                        Descricao = c.String(nullable: false, maxLength: 100, unicode: false),
                        CriadoEm = c.DateTime(nullable: false),
                        AtualizadoEm = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ListaDeTarefas", t => t.IdListaDeTarefas)
                .Index(t => t.IdListaDeTarefas);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Tarefas", "IdListaDeTarefas", "dbo.ListaDeTarefas");
            DropIndex("dbo.Tarefas", new[] { "IdListaDeTarefas" });
            DropTable("dbo.Tarefas");
            DropTable("dbo.ListaDeTarefas");
        }
    }
}
