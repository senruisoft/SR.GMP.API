using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Formatting.Compact;
using SR.GMP.EFCore;
using SR.GMP.WorkerService.WorkerJob;

namespace SR.GMP.WorkerService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Serilog配置
            Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Information()
                      .MinimumLevel.Override("Microsoft", LogEventLevel.Error)
                      .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning) // 降低EF日志级别
                      .Enrich.FromLogContext()                         
                      .WriteTo.Console()
                      //.WriteTo.File("Logs\\log.txt", rollingInterval: RollingInterval.Day)
                      .WriteTo.Async(config => config.File("Logs/log.txt",
                       outputTemplate: "{Timestamp:HH:mm} || {Level} || {SourceContext:l} || {Message} || end {NewLine}",
                       rollingInterval: RollingInterval.Day))
                      .CreateLogger();

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Service terminated unexpectedly!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    services.AddHostedService<Worker>();
                    services.AddDbContext<GMPContext>(options => options.UseSqlServer(hostContext.Configuration.GetConnectionString("GMPContext")));
                    services.AddSingleton<IJob, AlarmCheckJob>();
                }).UseSerilog(dispose: true);
    }
}
