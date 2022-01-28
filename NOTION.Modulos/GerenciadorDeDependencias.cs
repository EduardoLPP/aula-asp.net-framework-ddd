using Ninject.Modules;
using NOTION.Dominio.Interfaces.IUnidadeDeTrabalho;


namespace NOTION.Modulos
{
    internal class GerenciadorDeDependencias : NinjectModule
    {
        public override void Load()
        {
            Bind<IUnidadeDeTrabalho>().
                 .To<NotionUnidadeDeTrabalho>()
                 .WithConstructorArgument();
        }
    }
}
