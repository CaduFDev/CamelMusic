using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Repositories.Comum.Entity
{
    public class RepositorieGenericEntity<TEntity, TKey> : IRepositoriesGenerics<TEntity, TKey> where TEntity : class
    {
        protected readonly DbContext _context;

        public RepositorieGenericEntity(DbContext context)
        {
            _context = context;
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public void DeleteForId(TKey id)
        {
            TEntity entity = SelectForId(id);
            Delete(entity);
        }

        public void Inser(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            _context.SaveChanges();
        }

        public virtual List<TEntity> Select()
        {

            return _context.Set<TEntity>().ToList();
        }

        public virtual TEntity SelectForId(TKey id)
        {

            return _context.Set<TEntity>().Find(id);
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Attach(entity);
            _context.Entry(entity).State= EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
