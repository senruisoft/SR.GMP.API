using Microsoft.EntityFrameworkCore;
using SR.GMP.DataEntity.BaseEntity;
using SR.GMP.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
    {
        protected virtual GMPContext _dbContext { get; set; }

        public Repository(GMPContext context)
        {
            this._dbContext = context;
        }

        #region 新增实体
        public virtual TEntity Add(TEntity entity)
        {
            return _dbContext.Add(entity).Entity;
        }

        public virtual Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Add(entity));
        }

        public virtual void AddRange(IEnumerable<TEntity> entities)
        {
            _dbContext.AddRange(entities);
        }

        public virtual void AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            _dbContext.AddRangeAsync(entities, cancellationToken);
        }
        #endregion

        #region 更新实体
        public virtual TEntity Update(TEntity entity)
        {
            return _dbContext.Update(entity).Entity;
        }

        public virtual Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Update(entity));
        }

        public virtual TEntity Update(TEntity oriEntity, object entity)
        {
            _dbContext.Entry(oriEntity).State = EntityState.Unchanged;
            _dbContext.Entry(oriEntity).CurrentValues.SetValues(entity);
            return oriEntity;
        }
        #endregion

        #region 删除实体
        public virtual bool Remove(Entity entity)
        {
            _dbContext.Remove(entity);
            return true;
        }

        public virtual Task<bool> RemoveAsync(Entity entity, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(Remove(entity));
        }

        public virtual bool RemoveRange(IEnumerable<TEntity> entities)
        {
            _dbContext.RemoveRange(entities);
            return true;
        }

        public virtual Task<bool> RemoveRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken = default)
        {
            return Task.FromResult(RemoveRange(entities));
        }

        public virtual bool Remove(Expression<Func<TEntity, bool>> query)
        {
            _dbContext.RemoveRange(_dbContext.Set<TEntity>().Where(query));
            return true;
        }

        public virtual Task<bool> RemoveAsync(Expression<Func<TEntity, bool>> query)
        {
            return Task.FromResult(Remove(query));
        }
        #endregion

        #region 查询实体
        /// <summary>
        /// 获取实体集合
        /// </summary>
        /// <param name="tracking"></param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetQueryable(bool tracking = true)
        {
            return tracking ? _dbContext.Set<TEntity>() : _dbContext.Set<TEntity>().AsNoTracking();
        }

        /// <summary>
        /// 获取指定查询条件的实体集合
        /// </summary>
        /// <param name="query">查询条件</param>
        /// <param name="tracking">是否启用跟踪</param>
        /// <returns></returns>
        public virtual IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> query, bool tracking = true)
        {
            return tracking ? _dbContext.Set<TEntity>().Where(query) : _dbContext.Set<TEntity>().Where(query).AsNoTracking();
        }

        /// <summary>
        /// 实体是否存在
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        public virtual async Task<bool> IsExistAsync(Expression<Func<TEntity, bool>> query)
        {
            return await _dbContext.Set<TEntity>().FirstOrDefaultAsync(query) != null;
        }

        /// <summary>
        /// 实体是否存在
        /// </summary>
        /// <param name="id">实体主键</param>
        /// <returns></returns>
        public virtual bool IsExist(Expression<Func<TEntity, bool>> query)
        {
            return _dbContext.Set<TEntity>().FirstOrDefault(query) != null;
        }
        #endregion
    }


    public class Repository<TEntity, TKey> : Repository<TEntity>, IRepository<TEntity, TKey> where TEntity : Entity<TKey>
    {
        public Repository(GMPContext context) : base(context)
        {
        }

        public virtual TEntity InsertOrUpdate(TKey ID ,object entity)
        {
            var oriEntity = Find(ID);
            if (oriEntity != null)
            {
                return Update(oriEntity, entity);
            }
            else 
            {
                return Add(entity as TEntity);
            }
        }

        public virtual bool Remove(TKey id)
        {
            var entity = _dbContext.Find<TEntity>(id);
            if (entity == null)
            {
                return false;
            }
            _dbContext.Remove(entity);
            return true;
        }

        public virtual async Task<bool> RemoveAsync(TKey id, CancellationToken cancellationToken = default)
        {
            var entity = await _dbContext.FindAsync<TEntity>(new object[] { id }, cancellationToken);
            if (entity == null)
            {
                return false;
            }
            _dbContext.Remove(entity);
            return true;
        }

        public virtual TEntity Find(TKey id)
        {
            return _dbContext.Find<TEntity>(id);
        }

        public virtual async Task<TEntity> FindAsync(TKey id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.FindAsync<TEntity>(new object[] { id }, cancellationToken);
        }
    }
}
