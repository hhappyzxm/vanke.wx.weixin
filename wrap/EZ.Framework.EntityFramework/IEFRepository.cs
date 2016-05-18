using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EZ.Framework.EntityFramework
{
    public interface IEFRepository<TEntity> : IRepository<TEntity>
        where TEntity : IEntity
    {
        TEntity SingleOrDefault(Expression<Func<TEntity, bool>> filter);

        Task<TEntity> SingleOrDefaultAsync(Expression<Func<TEntity, bool>> filter);

        bool Any(Expression<Func<TEntity, bool>> filter);

        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> filter);

        int Count(Expression<Func<TEntity, bool>> filter);

        Task<int> CountAsync(Expression<Func<TEntity, bool>> filter);

        IEnumerable<TEntity> ToList(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
        
        Task<IEnumerable<TEntity>> ToListAsync(Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        IEnumerable<TResult> SelectList<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);

        Task<IEnumerable<TResult>> SelectListAsync<TResult>(Expression<Func<TEntity, TResult>> selector, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null);
    }
}
