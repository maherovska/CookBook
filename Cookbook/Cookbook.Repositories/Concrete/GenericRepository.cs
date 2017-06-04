using Cookbook.Entities.Entities;
using Cookbook.Entities.Context;
using Cookbook.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace Cookbook.Repositories.Concrete
{
    public class GenericRepository<TEntity> : IRepository<TEntity>
        where TEntity : class
    {
        internal CookBookDbContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(CookBookDbContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>> filter = null)
        {
            IQueryable<TEntity> query = dbSet;

            if (filter != null)
            {
                query.Where(filter);
            }

            return dbSet.ToList();
        }

        public virtual TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Insert(TEntity entity)
        {
            dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            dbSet.Attach(entity);
            context.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Delete(int id)
        {
            TEntity entity = dbSet.Find(id);
            Delete(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            if (context.Entry(entity).State == EntityState.Detached)
            {
                dbSet.Attach(entity);
            }

            dbSet.Remove(entity);
        }
    }
}
