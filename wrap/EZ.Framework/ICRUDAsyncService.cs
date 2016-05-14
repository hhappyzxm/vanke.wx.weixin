using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Framework
{
    public interface IRetrieveAsyncService<TEntity>
        where TEntity : IEntity
    {
        Task<TEntity> GetByKeyAsync(object key);

        Task<IEnumerable<TEntity>> GetAllAsync();
    }

    public interface ICreateAsyncService<in TEntity>
        where TEntity : IEntity
    {
        Task InsertAsync(TEntity entity);
    }

    public interface IUpdateAsyncService<in TEntity>
        where TEntity : IEntity
    {
        Task UpdateAsync(TEntity entity);
    }

    public interface IDeleteAsyncService<in TEntity>
        where TEntity : IEntity
    {
        Task RemoveAsync(object key);

        Task RemoveAsync(TEntity entity);
    }

    public interface ICRUDAsyncService<TEntity> : ICreateAsyncService<TEntity>, IRetrieveAsyncService<TEntity>, IUpdateAsyncService<TEntity>, IDeleteAsyncService<TEntity>
        where TEntity : IEntity
    {
    }
}
