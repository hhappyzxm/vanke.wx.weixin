using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EZ.Framework.NoRepository.EntityFramework
{
    public abstract class GenericService<TUnitOfWork, TEntity, TModel> : Service<TUnitOfWork>, ICRUDService<TModel>,
        ICRUDAsyncService<TModel>
        where TUnitOfWork : IDataContext
        where TEntity : class, IEntity, new()
        where TModel : IModel
    {
        public GenericService(TUnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        protected abstract Expression<Func<TEntity, TModel>> ModelSelector();

        protected abstract void ConvertToEntity(TModel model, ref TEntity targetEntity);

        #region GetByKey

        //private System.Data.Entity.Core.Objects.ObjectQuery<TEntity> BuildFindQuery(WrappedEntityKey key)
        //{
        //    StringBuilder stringBuilder = new StringBuilder();
        //    stringBuilder.AppendFormat("SELECT VALUE X FROM {0} AS X WHERE ", (object)this.QuotedEntitySetName);
        //    EntityKeyMember[] entityKeyValues = key.EntityKey.EntityKeyValues;
        //    ObjectParameter[] objectParameterArray = new ObjectParameter[entityKeyValues.Length];
        //    for (int index = 0; index < entityKeyValues.Length; ++index)
        //    {
        //        if (index > 0)
        //            stringBuilder.Append(" AND ");
        //        string name = string.Format((IFormatProvider)CultureInfo.InvariantCulture, "p{0}", new object[1]
        //        {
        //  (object) index.ToString((IFormatProvider) CultureInfo.InvariantCulture)
        //        });
        //        stringBuilder.AppendFormat("X.{0} = @{1}", (object)DbHelpers.QuoteIdentifier(entityKeyValues[index].Key), (object)name);
        //        objectParameterArray[index] = new ObjectParameter(name, entityKeyValues[index].Value);
        //    }
        //    return this.InternalContext.ObjectContext.CreateQuery<TEntity>(stringBuilder.ToString(), objectParameterArray);
        //}

        //public virtual TModel GetByKey(object key)
        //{
        //    //UnitOfWork.Set<TEntity>().Find()
        //    //var sql = "SELECT VALUE X FROM {0} AS X WHERE X.{1}=@id";
        //    //UnitOfWork.Set<TEntity>().SqlQuery("", key).Select()
        //    //var query = ((IObjectContextAdapter)UnitOfWork).ObjectContext.CreateQuery<TEntity>("SELECT VALUE X FROM {0} AS X WHERE X.{1}=@id", new ObjectParameter[] { new ObjectParameter("id", 1) });
        //    //return query.Select(ModelSelector()).SingleOrDefault();
        //}

        //public virtual async Task<TModel> GetByKeyAsync(object key)
        //{
        //    return await UnitOfWork.Set<TEntity>().Where(p => p.ID == key).Select(ModelSelector()).SingleOrDefaultAsync();
        //}

        public virtual TModel GetByKey(object key)
        {
            return default(TModel);
        }

        public virtual Task<TModel> GetByKeyAsync(object key)
        {
            return Task.FromResult(default(TModel));
        }

        #endregion

        #region GetAll

        public virtual IEnumerable<TModel> GetAll()
        {
            return UnitOfWork.Set<TEntity>().Select(ModelSelector()).ToList();
        }

        public virtual async Task<IEnumerable<TModel>> GetAllAsync()
        {
            return await UnitOfWork.Set<TEntity>().Select(ModelSelector()).ToListAsync();
        }

        #endregion

        #region Insert

        public virtual void Insert(TModel model)
        {
            TEntity entity = new TEntity();

            ConvertToEntity(model, ref entity);

            InsertEntity(entity);
        }

        protected virtual void InsertEntity(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Add(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task InsertAsync(TModel model)
        {
            TEntity entity = new TEntity();

            ConvertToEntity(model, ref entity);

            await InsertEntityAsync(entity);
        }

        protected virtual async Task InsertEntityAsync(TEntity entity)
        {
            UnitOfWork.Set<TEntity>().Add(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region Update

        public virtual void Update(object key, TModel model)
        {
            var entity = UnitOfWork.Set<TEntity>().Find(key);
            ConvertToEntity(model, ref entity);

            UpdateEntity(entity);
        }

        protected virtual void UpdateEntity(TEntity entity)
        {
            UnitOfWork.SaveChanges();
        }

        public virtual async Task UpdateAsync(object key, TModel model)
        {
            var entity = await UnitOfWork.Set<TEntity>().FindAsync(key);
            ConvertToEntity(model, ref entity);

            await UpdateEntityAsync(entity);
        }

        public virtual async Task UpdateEntityAsync(TEntity entity)
        {
            await UnitOfWork.SaveChangesAsync();
        }

        #endregion

        #region Remove

        public virtual void Remove(object key)
        {
            Remove(UnitOfWork.Set<TEntity>().Find(key));
        }

        protected virtual void Remove(TEntity entity)
        {
            if (UnitOfWork.Entry(entity).State == EntityState.Detached)
            {
                UnitOfWork.Set<TEntity>().Attach(entity);
            }

            UnitOfWork.Set<TEntity>().Remove(entity);
            UnitOfWork.SaveChanges();
        }

        public virtual async Task RemoveAsync(object key)
        {
            var entity = await UnitOfWork.Set<TEntity>().FindAsync(key);
            await RemoveAsync(entity);
        }

        protected virtual async Task RemoveAsync(TEntity entity)
        {
            if (UnitOfWork.Entry(entity).State == EntityState.Detached)
            {
                UnitOfWork.Set<TEntity>().Attach(entity);
            }

            UnitOfWork.Set<TEntity>().Remove(entity);
            await UnitOfWork.SaveChangesAsync();
        }

        #endregion
    }
}
