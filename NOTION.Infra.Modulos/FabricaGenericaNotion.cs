using Ninject;
using Ninject.Parameters;


namespace NOTION.Infra.Modulos
{
    public class FabricaGenericaNotion
    { 
        private static StandardKernel _Kernel { get; set; }

        private static StandardKernel Kernel
        {
            get
            {
                if(_Kernel == null)
                { 
                    _Kernel = new StandardKernel(new GerenciadorDeDependencias());
                }

                return _Kernel;
            }
        }

        public static T Crie<T>(params IParameter[] parametros)
        {
            return Kernel.Get<T>(parametros);
        }
    }
}
