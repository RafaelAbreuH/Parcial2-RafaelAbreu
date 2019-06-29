using Parcial2_RafaelAbreu.DAL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Parcial2_RafaelAbreu.BLL
{
    public class RepositorioBase<T> : IDisposable, IRepository<T> where T : class
    {
        internal Contexto db;

        public RepositorioBase()
        {
            db = new Contexto();
        }

        public virtual bool Guardar(T entity)
        {
            bool paso = false;

            try
            {
                if (db.Set<T>().Add(entity) != null)
                    paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }

        public virtual bool Modificar(T entity)
        {
            bool paso = false;

            try
            {
                db.Entry(entity).State = EntityState.Modified;
                paso = db.SaveChanges() > 0;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        public virtual T Buscar(int id)
        {
            T entity;

            try
            {
                entity = db.Set<T>().Find(id);

            }
            catch (Exception)
            {
                throw;
            }

            return entity;
        }
        public virtual List<T> GetList(Expression<Func<T, bool>> expression)
        {
            List<T> lista = new List<T>();

            try
            {
                lista = db.Set<T>().Where(expression).ToList();

            }
            catch (Exception)
            {
                throw;
            }

            return lista;

        }
        public virtual bool Eliminar(int id)
        {
            bool paso = false;

            try
            {
                T entity = this.Buscar(id);
                db.Entry(entity).State = EntityState.Deleted;

            }
            catch (Exception)
            {
                throw;
            }

            return paso;
        }
        public virtual void Dispose()
        {
            db.Dispose();
        }
    }
}
