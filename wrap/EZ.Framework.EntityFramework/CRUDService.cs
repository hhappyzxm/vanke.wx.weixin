using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using EZ.Framework.Core;

namespace EZ.Framework.EntityFramework
{
    public class CRUDService<TUnitOfWork, TRepository, TEntity> : Service<TUnitOfWork>, ICRUDService<TEntity>, ICRUDAsyncService<TEntity>
        where TUnitOfWork : IDataContext
        where TRepository : IRepository<TEntity>
        where TEntity : IEntity
    {
        protected readonly TRepository Repository;

        public CRUDService(TUnitOfWork unitOfWork, TRepository repository ) : base(unitOfWork)
        {
            if (repository == null) throw new ArgumentNullException(nameof(repository));

            Repository = repository;
        }

        #region GetByKey

        public TEntity GetByKey(object key)
        {
            return Repository.GetByKey(key);
        }

        public async Task<TEntity> GetByKeyAsync(object key)
        {
            return await Repository.GetByKeyAsync(key);
        }

        #endregion

        #region GetAll

        public IEnumerable<TEntity> GetAll()
        {
            return Repository.GetAll();
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await Repository.GetAllAsync();
        }

        #endregion

        #region Insert

        protected virtual void BeforeInsert(TEntity entity)
        {
        }

        public virtual void Insert(TEntity entity)
        {
            BeforeInsert(entity);

            Repository.Insert(entity);
            UnitOfWork.SaveChanges();

            AfertInsert(entity);
        }

        public virtual void AfertInsert(TEntity entity)
        {
        }

        protected virtual async Task BeforeInsertAsync(TEntity entity)
        {
            await Task.FromResult(0);
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            await BeforeInsertAsync(entity);

            Repository.Insert(entity);
            await UnitOfWork.SaveChangesAsync();

            await AfterInsertAsync(entity);
        }

        protected virtual async Task AfterInsertAsync(TEntity entity)
        {
            await Task.FromResult(0);
        }

        #endregion

        #region Update

        protected virtual void BeforeUpdate(TEntity entity)
        {
        }

        public virtual void Update(TEntity entity)
        {
            BeforeUpdate(entity);

            Repository.Update(entity);
            UnitOfWork.SaveChanges();

            AfertUpdate(entity);
        }

        public virtual void AfertUpdate(TEntity entity)
        {
        }

        protected virtual async Task BeforeUpdateAsync(TEntity entity)
        {
            await Task.FromResult(0);
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            await BeforeUpdateAsync(entity);

            Repository.Update(entity);
            await UnitOfWork.SaveChangesAsync();

            await AfterUpdateAsync(entity);
        }

        protected virtual async Task AfterUpdateAsync(TEntity entity)
        {
            await Task.FromResult(0);
        }

        #endregion

        #region Remove

        protected virtual void BeforeRemove(TEntity entity)
        {
        }

        public virtual void Remove(TEntity entity)
        {
            BeforeRemove(entity);

            Repository.Remove(entity);
            UnitOfWork.SaveChanges();

            AfertRemove(entity);
        }

        public virtual void AfertRemove(TEntity entity)
        {
        }

        protected virtual async Task BeforeRemoveAsync(TEntity entity)
        {
            await Task.FromResult(0);
        }

        public virtual async Task RemoveAsync(TEntity entity)
        {
            await BeforeRemoveAsync(entity);

            Repository.Remove(entity);
            await UnitOfWork.SaveChangesAsync();

            await AfterRemoveAsync(entity);
        }

        protected virtual async Task AfterRemoveAsync(TEntity entity)
        {
            await Task.FromResult(0);
        }

        #endregion
    }
}
