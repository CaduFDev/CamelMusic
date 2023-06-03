using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CamelDev.Repositories.Comum
{
    public interface IRepositoriesGenerics<TEntity, TKey> where TEntity : class
    {
        List<TEntity> Select();
        TEntity SelectForId(TKey id);
        void Inser(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void DeleteForId(TKey id);
    }
}
