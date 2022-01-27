using NOTION.Dominio.Interfaces.Repositorios;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace NOTION.Infra.Data.Repositorio
{
    internal class Repositorio<T> : IRepositorio<T> where T : class
    {
        public DbContext Contexto { get; private set; }

        public Repositorio(DbContext contexto)
        {
            this.Contexto = contexto;
        }

        public T Obtenha(params object[] chaves)
        {
            return this.Contexto.Set<T>().Find(chaves);
        }

        public IEnumerable<T> Obtenha(Expression<Func<T, bool>> predicado)
        {
            return this.Contexto.Set<T>().Where(predicado);
        }

        public IEnumerable<T> Obtenha()
        {
            return this.Contexto.Set<T>();
        }

        public void Adcione(T objeto)
        {
            this.Contexto.Set<T>().Add(objeto);
        }

        public void Atualiza(T objeto)
        {
            this.Contexto.Entry<T>(objeto).State = EntityState.Modified;
        }

        public void Atualize(T objeto)
        {
            this.Contexto.Set<T>().Remove(objeto);
        }
    }
}
