using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using SR.GMP.EFCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        /// <summary>
        /// 连接上下文对象
        /// </summary>
        private GMPContext _dbContext;

        /// <summary>
        /// 事务对象
        /// </summary>
        private IDbContextTransaction _currentTransaction;

        public UnitOfWork(GMPContext dbContext)
        {
            _dbContext = dbContext;
        }

        /// <summary>
        /// 保存上下文数据
        /// </summary>
        /// <returns></returns>
        public bool Commit()
        {
            return _dbContext.SaveChanges() > 0;
        }

        /// <summary>
        /// 保存上下文数据
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public Task<int> CommitAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// 获取当前事务对象
        /// </summary>
        /// <returns></returns>
        public IDbContextTransaction GetCurrentTransaction() => _currentTransaction;

        /// <summary>
        /// 判断是否有活动事务
        /// </summary>
        public bool HasActiveTransaction => _currentTransaction != null;

        /// <summary>
        /// 开启事务
        /// </summary>
        /// <returns></returns>
        public Task<IDbContextTransaction> BeginTransactionAsync()
        {
            if (_currentTransaction != null) return null;
            _currentTransaction = _dbContext.Database.BeginTransaction();
            return Task.FromResult(_currentTransaction);
        }

        /// <summary>
        /// 提交事务
        /// </summary>
        /// <returns></returns>
        public async Task CommitTransactionAsync()
        {
            if (_currentTransaction == null) throw new ArgumentNullException(nameof(_currentTransaction));

            try
            {
                await _dbContext.SaveChangesAsync();
                _currentTransaction.Commit();
            }
            catch
            {
                RollbackTransaction();
                throw;
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        /// <summary>
        /// 回滚事务
        /// </summary>
        public void RollbackTransaction()
        {
            try
            {
                _currentTransaction?.Rollback();
            }
            finally
            {
                if (_currentTransaction != null)
                {
                    _currentTransaction.Dispose();
                    _currentTransaction = null;
                }
            }
        }

        public void Dispose()
        {
            if (_currentTransaction != null)
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }
    }
}
