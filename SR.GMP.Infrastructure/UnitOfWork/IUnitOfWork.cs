using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SR.GMP.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork : ITransaction, IDisposable
    {
        bool Commit();

        Task<int> CommitAsync(CancellationToken cancellationToken = default);
    }
}
