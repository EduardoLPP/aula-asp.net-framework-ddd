using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Infra.Data.Basicos.Atributos 
{
    public class AtributoDeRepositorioImplementado : Attribute
    {
        public Type TipoBase { get; private set; }

        public AtributoDeRepositorioImplementado(Type tipo)
        {
            this.TipoBase = tipo;
        }

    }
}
