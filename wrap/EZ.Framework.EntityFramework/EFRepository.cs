using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace EZ.Framework.EntityFramework
{
    public class EFRepository<TEntity> : RepositoryAbstract<TEntity>, IEFRepository<TEntity>
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

        public override void Remove(object key)
        {
            var entity = DbSet.Find(key);
            Remove(entity);
        }

        public override void Remove(TEntity entity)
        {
            if (DataContext.Entry(entity).State == EntityState.Detached)
            {
                DbSet.Attach(entity);
            }
            DbSet.Remove(entity);
        }

        #region ToList

        public IEnumerable<TEntity> ToList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }

        public async Task<IEnumerable<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null)
        {
            IQueryable<TEntity> query = DbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }

        #endregion

        #region SingleOrDefualt

        public TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.SingleOrDefault(filter);
        }

        public async Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.SingleOrDefaultAsync(filter);
        }

        #endregion

        #region Any

        public bool Any(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Any(filter);
        }

        public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.AnyAsync(filter);
        }

        #endregion

        #region Count

        public int Count(Expression<Func<TEntity, bool>> filter)
        {
            return DbSet.Count(filter);
        }

        public async Task<int> CountAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await DbSet.CountAsync(filter);
        }

        #endregion
    }
}
