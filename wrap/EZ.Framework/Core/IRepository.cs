using System.Collections.Generic;
using System.Threading.Tasks;

namespace EZ.Framework.Core
{
    public interface IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity GetByKey(object key);
        Task<TEntity> GetByKeyAsync(object key);

        IEnumerable<TEntity> GetAll();
        Task<IEnumerable<TEntity>> GetAllAsync();

        void Insert(TEntity entity);

        void Update(TEntity entity);

        void Delete(object key);

        void Delete(TEntity entity);
    }
}