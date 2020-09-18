using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SR.GMP.EFCore;
using SR.GMP.WorkerService.WorkerJob;

namespace SR.GMP.WorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceScopeFactory _serviceScopeFactory;
        private DateTime checkTime;
        IJob _job;

        public Worker(ILogger<Worker> logger, IServiceScopeFactory serviceScopeFactory, IJob job)
        {
            _logger = logger;
            _serviceScopeFactory = serviceScopeFactory;
            _job = job;
            checkTime = DateTime.Now;
        }

        //重写BackgroundService.StartAsync方法，在开始服务的时候，执行一些处理逻辑
        public override async Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker starting at: {time}", DateTimeOffset.Now);

            await base.StartAsync(cancellationToken);
        }

        //重写BackgroundService.StopAsync方法，在结束服务的时候，执行一些处理逻辑
        public override async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogInformation("Worker stopping at: {time}", DateTimeOffset.Now);

            await base.StopAsync(cancellationToken);
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                DateTime lastCheckTime = checkTime;
                checkTime = DateTime.Now;
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                try
                {
                    await Task.WhenAll(_job.init(lastCheckTime, stoppingToken));
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex.Message);
                }
                await Task.Delay(5000, stoppingToken);
            }
        }
    }
}
