using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Threading.Tasks;

namespace EZ.Framework.NoRepository.EntityFramework
{
    public interface IDataContext : IUnitOfWork, IObjectContextAdapter
    {
        int SaveChanges();

        Task<int> SaveChangesAsync();

        DbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}
