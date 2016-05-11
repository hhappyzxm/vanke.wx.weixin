using System;
using System.Threading.Tasks;
using EZ.Framework.Core;

namespace EZ.Framework.EntityFramework
{
    public class CRUDService<TUnitOfWork, TRepository, TEntity> : Service<TUnitOfWork>
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
    }
}
