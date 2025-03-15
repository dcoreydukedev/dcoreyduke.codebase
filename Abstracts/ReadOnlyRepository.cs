/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using DCoreyDuke.CodeBase.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace DCoreyDuke.CodeBase.Abstracts
{
    /// <summary>
    /// Contains Read Only Operations for Entities All read only repositories inherit from this class.
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public abstract class ReadOnlyRepository<TEntity> : IReadOnlyRepository<TEntity> where TEntity : class
    {
        private readonly DbSet<TEntity> _dbSet;

        public DbContext Context { get; }

        protected ReadOnlyRepository(DbContext context)
        {
            Context = context;
            _dbSet = context.Set<TEntity>();
        }
      
        public virtual async Task<TEntity> GetAsync(int id)
        {
            return (await _dbSet.FindAsync(id))!;
        }

        /// <summary>
        /// Provides a way of searching a repository by providing a search expression
        /// </summary>
        /// <param name="filter">The search expression (ie, x => x.Id == entityId)</param>
        /// <param name="orderBy">The orderby expression</param>
        /// <param name="includes">Specify what entity relationships to include as defined by the key constraints in the database</param>
        /// <returns></returns>
        public virtual IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params string[] includes)
        {
            IQueryable<TEntity> query = _dbSet;

            query = includes.Aggregate(query, (current, include) => current.Include(include));

            if (filter != null)
                query = query.Where(filter);

            return orderBy != null ? orderBy(query).ToList() : query.ToList();
        }

     
    }
}

