using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SR.GMP.WorkerService.WorkerJob
{
    public interface IJob
    {
        List<Task> init(DateTime lastCheckTime, CancellationToken stoppingToken);
    }
}
