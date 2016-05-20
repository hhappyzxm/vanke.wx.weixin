using System.Collections.Generic;

namespace EZ.Framework
{
    public interface IRetrieveService<out TModel>
       where TModel : IModel
    {
        TModel GetByKey(object key);

        IEnumerable<TModel> GetAll();
    }

    public interface ICreateService<in TModel>
        where TModel : IModel
    {
        void Insert(TModel model);
    }

    public interface IUpdateService<in TModel>
        where TModel : IModel
    {
        void Update(object key, TModel model);
    }

    public interface IDeleteService
    {
        void Remove(object key);
    }

    public interface ICRUDService<TModel> : ICreateService<TModel>, IRetrieveService<TModel>, IUpdateService<TModel>, IDeleteService
        where TModel : IModel
    {
    }
}
