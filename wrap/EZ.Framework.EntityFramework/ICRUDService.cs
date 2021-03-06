﻿using System.Collections.Generic;

namespace EZ.Framework.EntityFramework
{
    public interface IRetrieveService<out TEntity>
       where TEntity : IEntity
    {
        TEntity GetByKey(object key);

        IEnumerable<TEntity> GetAll();
    }

    public interface ICreateService<in TEntity>
        where TEntity : IEntity
    {
        void Insert(TEntity entity);
    }

    public interface IUpdateService<in TEntity>
        where TEntity : IEntity
    {
        void Update(TEntity entity);
    }

    public interface IDeleteService<in TEntity>
        where TEntity : IEntity
    {
        void Remove(object key);

        void Remove(TEntity entity);
    }

    public interface ICRUDService<TEntity> : ICreateService<TEntity>, IRetrieveService<TEntity>, IUpdateService<TEntity>, IDeleteService<TEntity>
        where TEntity : IEntity
    {
    }
}
