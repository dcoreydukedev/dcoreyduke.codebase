/*************************************************************************
 * Author: DCoreyDuke
 ************************************************************************/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DCoreyDuke.CodeBase.Interfaces
{

    public interface IRepository<TEntity, TKey> where TEntity : class
    {
        Task InsertAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<TEntity> GetAsync(TKey id);
        IEnumerable<TEntity> Get(Expression<Func<TEntity, bool>>? filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? orderBy = null, params string[] includes);
        Task<int> SaveChangesAsync();
        public DbContext Context { get; }
    }

    public interface IRepository<TEntity> : IRepository<TEntity, int> where TEntity : class
    {

    }

}

