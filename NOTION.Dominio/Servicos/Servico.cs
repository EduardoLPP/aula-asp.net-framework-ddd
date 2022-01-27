using NOTION.Dominio.Interfaces.IUnidadeDeTrabalho;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Dominio.Servicos
{
    public abstract class Servico
    {
        protected IUnidadeDeTrabalho UnidadeDeTrabalho { get; private set; }

        public Servico(IUnidadeDeTrabalho unidadeDeTrabalho)
        {
            this.UnidadeDeTrabalho = unidadeDeTrabalho;
        }
    }
}
