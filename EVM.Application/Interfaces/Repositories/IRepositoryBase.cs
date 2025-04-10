using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EVM.Application.Interfaces.Repositories
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task<TEntity> AddAsync(TEntity entity);
        Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate);
        Task<int> CountAsync();
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindAsync();
        ValueTask<TEntity?> FindOneAsync(params object[] ids);
        Task<TEntity?> FindOneWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<List<TEntity>> FindWhereAsync(Expression<Func<TEntity, bool>> predicate);
        Task<TEntity> RemoveAsync(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
