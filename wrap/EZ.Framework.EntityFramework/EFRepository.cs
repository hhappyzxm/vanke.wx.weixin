using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using EZ.Framework.Core;

namespace EZ.Framework.EntityFramework
{
    public class EFRepository<TEntity> : RepositoryAbstract<TEntity>
        where TEntity : class, IEntity
    {
        protected readonly IDataContext DataContext;
        protected readonly DbSet<TEntity> DbSet; 

        public EFRepository(IDataContext dataContext)
        {
            if(dataContext == null)throw new ArgumentNullException(nameof(dataContext));

            DataContext = dataContext;
            DbSet = dataContext.Set<TEntity>();
        }

        public override TEntity GetByKey(object key)
        {
            return DbSet.Find(key);
        }

        public override async Task<TEntity> GetByKeyAsync(object key)
        {
            return await DbSet.FindAsync(key);
        }

        public override IEnumerable<TEntity> GetAll()
        {
            return DbSet.ToList();
        }

        public override async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public override void Insert(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public override void Update(TEntity entity)
        {
            DbSet.Attach(entity);
            DataContext.Entry(entity).State = EntityState.Modified;
        }

        public override void Delete(object key)
        {
            var entity = DbSet.Find(key);
            Delete(entity);
        }

        public override void Delete(TEntity entity)
        {
            if (DataContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }
    }
}
