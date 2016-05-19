using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Framework
{
    public interface IRetrieveAsyncService<TResult>
    {
        Task<TResult> GetByKeyAsync(object key);

        Task<IEnumerable<TResult>> GetAllAsync();
    }

    public interface ICreateAsyncService<in TResult>
    {
        Task InsertAsync(TResult entity);
    }

    public interface IUpdateAsyncService<in TResult>
    {
        Task UpdateAsync(TResult entity);
    }

    public interface IDeleteAsyncService<in TResult>
    {
        Task RemoveAsync(object key);

        Task RemoveAsync(TResult entity);
    }

    public interface ICRUDAsyncService<TResult> : ICreateAsyncService<TResult>, IRetrieveAsyncService<TResult>, IUpdateAsyncService<TResult>, IDeleteAsyncService<TResult>
    {
    }
}
