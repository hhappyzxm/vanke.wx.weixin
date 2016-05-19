using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace EZ.Framework.NoRepository.EntityFramework
{
    public class GenericService<TUnitOfWork, TEntity> : Service<TUnitOfWork>, ICRUDService<TEntity>, ICRUDAsyncService<TEntity>
        where TUnitOfWork : IDataContext
        where TEntity :class, IEntity
    {
        public GenericService(TUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }
        
        #region GetByKey

        public virtual TEntity GetByKey(object key)
        {
            return UnitOfWork.Set<TEntity>().Find(key);
        }

        public virtual async Task<TEntity> GetByKeyAsync(object key)
        {
            return await UnitOfWork.Set<TEntity>().FindAsync(key);
        }

        #endregion

        #region GetAll

        public virtual IEnumerable<TEntity> GetAll()
        {
            return UnitOfWork.Set<TEntity>().ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await UnitOfWork.Set<TEntity>().ToListAsync();
        }

        #endregion

        #region Insert

        public virtual void Insert(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region Update

        public virtual void Update(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Attach(entity);
            UnitOfWork.Entry(entity).State = EntityState.Modified;

            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Attach(entity);
            UnitOfWork.Entry(entity).State = EntityState.Modified;

            await UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region Remove

        public virtual void Remove(TEntity entity)
        {
            if (UnitOfWork.Entry(entity).State == EntityState.Detached)
            {
                UnitOfWork.Set<TEntity>().Attach(entity);
            }

            UnitOfWork.Set<TEntity>().Remove(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual void Remove(object key)
        {
            Remove(UnitOfWork.Set<TEntity>().Find(key));
        }


        public virtual async Task RemoveAsync(TEntity entity)
        {
            if (UnitOfWork.Entry(entity).State == EntityState.Detached)
            {
                UnitOfWork.Set<TEntity>().Attach(entity);
            }

            UnitOfWork.Set<TEntity>().Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        public virtual async Task RemoveAsync(object key)
        {
            var entity = await UnitOfWork.Set<TEntity>().FindAsync(key);
            await RemoveAsync(entity);
        }

        #endregion
    }

    public class GenericService<TUnitOfWork, TEntity, TModel> : GenericService<TUnitOfWork, TEntity>
        where TUnitOfWork : IDataContext
        where TEntity : class, IEntity
        where TModel : IModel
    {
        public GenericService(TUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        #region GetByKey

        //public virtual TModel GetByKeyToModel(object key)
        //{
        //    var entity = UnitOfWork.Set<TEntity>().Find(key);
        //}

        //public virtual async Task<TEntity> GetByKeyAsync(object key)
        //{
        //    return await UnitOfWork.Set<TEntity>().FindAsync(key);
        //}

        //#endregion

        //#region Insert

        //public virtual void InsertFromModel(TModel model)
        //{
        //    Insert(model.ToEntity<TEntity>());
        //}

        //public virtual async Task InsertFromModelAsync(TModel model)
        //{
        //    await InsertAsync(model.ToEntity<TEntity>());
        //}

        //#endregion

        //#region Update

        //public virtual void UpdateFromModel(TModel model)
        //{
        //    Update(model.ToEntity<TEntity>());
        //}

        //public virtual async Task UpdateFromModelAsync(TModel model)
        //{
        //    await UpdateAsync(model.ToEntity<TEntity>());
        //}

        #endregion
    }
}
