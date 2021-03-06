﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Framework
{
    public abstract class RepositoryAbstract<TEntity> : IRepository<TEntity>
         where TEntity : class, IEntity
    {
        

        //public virtual IEnumerable<TEntity> Get(
        //    Expression<Func<TEntity, bool>> filter = null,
        //    Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
        //    string includeProperties = "")
        //{
        //    IQueryable<TEntity> query = dbSet;

        //    if (filter != null)
        //    {
        //        query = query.Where(filter);
        //    }

        //    foreach (var includeProperty in includeProperties.Split
        //        (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
        //    {
        //        query = query.Include(includeProperty);
        //    }

        //    if (orderBy != null)
        //    {
        //        return orderBy(query).ToList();
        //    }
        //    else
        //    {
        //        return query.ToList();
        //    }
        //}

        public abstract TEntity GetByKey(object key);
        public abstract Task<TEntity> GetByKeyAsync(object key);

        public abstract IEnumerable<TEntity> GetAll();
        public abstract Task<IEnumerable<TEntity>> GetAllAsync();

        public abstract void Insert(TEntity entity);

        public abstract void Update(TEntity entity);

        public abstract void Remove(object key);
        public abstract void Remove(TEntity entity);
    }
}
