using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Framework
{
    public interface IRetrieveAsyncService<TModel>
        where TModel : IModel
    {
        Task<TModel> GetByKeyAsync(object key);

        Task<IEnumerable<TModel>> GetAllAsync();
    }

    public interface ICreateAsyncService<in TModel>
        where TModel : IModel
    {
        Task InsertAsync(TModel model);
    }

    public interface IUpdateAsyncService<in TModel>
        where TModel : IModel
    {
        Task UpdateAsync(object key, TModel model);
    }

    public interface IDeleteAsyncService
    {
        Task RemoveAsync(object key);
    }

    public interface ICRUDAsyncService<TModel> : ICreateAsyncService<TModel>, IRetrieveAsyncService<TModel>, IUpdateAsyncService<TModel>, IDeleteAsyncService
        where TModel : IModel
    {
    }
}
