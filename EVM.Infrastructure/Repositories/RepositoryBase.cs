using System.Linq.Expressions;
using EVM.Application.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace EVM.Infrastructure.Repositories
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        protected DbContext Context { get; }
        protected DbSet<TEntity> Entities => Context.Set<TEntity>();

        public RepositoryBase(DbContext context)
        {
            Context = context;
        }

        public virtual Task<List<TEntity>> FindAsync()
        {
            return Entities.ToListAsync();
        }

        public virtual Task<List<TEntity>> FindWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.Where(predicate).ToListAsync();
        }

        public virtual Task<int> CountAsync()
        {
            return Entities.CountAsync();
        }

        public virtual Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.CountAsync(predicate);
        }

        public virtual ValueTask<TEntity?> FindOneAsync(params object[] ids)
        {
            return Entities.FindAsync(ids);
        }

        public virtual Task<TEntity?> FindOneWhereAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.FirstOrDefaultAsync(predicate);
        }

        public Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return Entities.AnyAsync(predicate);
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            EntityEntry<TEntity> entry = Context.Add(entity);
            entry.State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            EntityEntry<TEntity> entry = Context.Update(entity);
            entry.State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entry.Entity;
        }

        public virtual async Task<TEntity> RemoveAsync(TEntity entity)
        {
            EntityEntry<TEntity> entry = Context.Remove(entity);
            entry.State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
