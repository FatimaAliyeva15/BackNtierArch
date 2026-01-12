using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.Repositories.Abstract
{
    public interface IBaseRepository<TEntity> where TEntity : class, new()
    {
        Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> func = null, params string[] includes);
        Task<List<TEntity>> GetAllPaginatedAsync(int page, int size, Expression<Func<TEntity, bool>> func = null, params string[] includes);
        Task<TEntity> Get(Expression<Func<TEntity, bool>> func, params string[] includes);
        Task AddAsync(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
    }
}
