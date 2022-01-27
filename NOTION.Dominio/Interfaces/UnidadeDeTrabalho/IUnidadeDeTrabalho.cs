using NOTION.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NOTION.Dominio.Interfaces.IUnidadeDeTrabalho
{
    public interface IUnidadeDeTrabalho : IDisposable
    {

        int SalveAlteracoes();
        void InicieTransacao();
        void FinalizeTransacao();
        void RevertaTransacao();
        IRepositorio<T> ObtenhaRepositorio<T>() where T : class;
        TRepo ObtenhaRepositorio<T, TRepo>() where T : class where TRepo : class;

    }
}
