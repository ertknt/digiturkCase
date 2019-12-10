using System;
using System.Collections.Generic;
using System.Text;

namespace Ertan.Kanter.Repository
{
    public class EntityRepository
    {
        public interface IDataRepository<TEntity>
        {
            IEnumerable<TEntity> GetAll();
            TEntity Get(long id);
            void Add(TEntity entity);
            void Update(TEntity dbEntity, TEntity entity);
            void Delete(TEntity entity);
        }
    }
}
