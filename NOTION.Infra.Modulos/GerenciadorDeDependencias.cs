using Ninject.Modules;
using NOTION.Dominio.Interfaces.IUnidadeDeTrabalho;
using NOTION.Infra.Data.UnidadeDeTrabalho;

namespace NOTION.Infra.Modulos
{
    internal class GerenciadorDeDependencias : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnidadeDeTrabalho>()
                .To<NotionUnidadeDeTrabalho>();
        }
    }
}
