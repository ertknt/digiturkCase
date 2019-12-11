using System;
using System.Collections.Generic;
using System.Text;

namespace Ertan.Kanter.Repository
{
    public interface IDataRepository<TEntity>
    {
        IEnumerable<TEntity> GetAll();
        TEntity Get(long id);
        int Add(TEntity entity);
        int Update(TEntity dbEntity, TEntity entity);
        int Delete(TEntity entity);
    }
}
