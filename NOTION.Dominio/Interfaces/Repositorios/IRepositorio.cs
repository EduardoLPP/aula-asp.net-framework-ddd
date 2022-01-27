using NOTION.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NOTION.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<T> where T : class
    {   /// <summary>
    /// Obtém único chave primária
    /// </summary>
    /// <param name="chaves">Chave Primária</param>
    /// <returns></returns>
        T Obtenha(params object[] chaves);
        /// <summary>
        /// Obtém lista de tarefas através de predicado
        /// </summary>
        /// <param name="predicado">Predicado ou filtragem</param>
        /// <returns></returns>
        IEnumerable<T> Obtenha(Expression<Func<T, bool>> predicado);
        /// <summary>
        /// Obtém todos
        /// </summary>
        /// <returns>Lista de Objetos</returns>
        IEnumerable<T> Obtenha();

        void Adcione(T objeto);
        void Atualiza(T objeto);
        void Atualize(T objeto);
        void Remova(Tarefa tarefa);
    }
}
