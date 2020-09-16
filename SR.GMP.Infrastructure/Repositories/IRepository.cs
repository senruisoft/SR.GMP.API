using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.BaseEntity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.Repositories
{
    public interface IRepository<TEntity> where TEntity : Entity
    {
        TEntity Add(TEntity entity);
        Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        void AddRange(IEnumerable<TEntity> entities);
        void AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        TEntity Update(TEntity entity);
        Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        bool Remove(Entity entity);
        Task<bool> RemoveAsync(Entity entity, CancellationToken cancellationToken = default);
        bool RemoveRange(IEnumerable<TEntity> entities);
        Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default);
        bool Remove(Expression<Func<TEntity, bool>> query);
        Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> query);
        IQueryable<TEntity> GetQueryable(bool tracking = true);
        IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> query = null, bool tracking = true);
        Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> query);
        bool IsExist(Expression<Func<TEntity, bool>> query);
    }

    public interface IRepository<TEntity, TKey> : IRepository<TEntity> where TEntity : Entity<TKey>
    {
        void InsertOrUpdate(TEntity entity);
        bool Remove(TKey id);
        Task<bool> RemoveAsync(TKey id, CancellationToken cancellationToken = default);
        TEntity Find(TKey id);
        Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken = default);
    }
}
