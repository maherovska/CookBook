using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Cookbook.Repositories.Abstract
{
    public interface IRepository<TEntity>
        where TEntity: class
    {
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null);
        TEntity GetById(int id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Delete(int id);
    }
}
