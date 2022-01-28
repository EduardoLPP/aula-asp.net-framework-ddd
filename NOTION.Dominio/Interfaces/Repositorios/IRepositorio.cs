using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace NOTION.Dominio.Interfaces.Repositorios
{
    public interface IRepositorio<T> where T : class
    {
        /// <summary>
        /// Obtém único através da chave primária
        /// </summary>
        /// <param name="chaves">Chave Primária</param>
        /// <returns>Objeto</returns>
        T Obtenha(params object[] chaves);

        /// <summary>
        /// Obtém lista de itens através de um predicado
        /// </summary>
        /// <param name="predicado">Predicado de filtragem</param>
        /// <returns>Lista de Objetos</returns>
        IEnumerable<T> Obtenha(Expression<Func<T, bool>> predicado);

        /// <summary>
        /// Obtém Todos
        /// </summary>
        /// <returns>Lista de Objetos</returns>
        IEnumerable<T> Obtenha();

        void Adicione(T objeto);

        void Atualize(T objeto);

        void Remova(T objeto);
    }
}
