using System.Collections.Generic;

namespace EZ.Framework
{
    public interface IRetrieveService<out TResult>
    {
        TResult GetByKey(object key);

        IEnumerable<TResult> GetAll();
    }

    public interface ICreateService<in TResult>
    {
        void Insert(TResult entity);
    }

    public interface IUpdateService<in TResult>
    {
        void Update(TResult entity);
    }

    public interface IDeleteService<in TResult>
    {
        void Remove(object key);

        void Remove(TResult entity);
    }

    public interface ICRUDService<TResult> : ICreateService<TResult>, IRetrieveService<TResult>, IUpdateService<TResult>, IDeleteService<TResult>
    {
    }
}
