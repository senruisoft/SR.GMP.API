using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using SR.GMP.EFCore;

namespace SR.GMP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region SeriLog配置
            Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Information()
                      .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
                      .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning) // 降低EF日志级别
                      .Enrich.FromLogContext()
                      // 写Error日志
                      .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Error).WriteTo.Async(config => config.File("Logs/error/log.txt",
                       outputTemplate: "{Timestamp:HH:mm} || {Level} || {SourceContext:l} || {Message} || end {NewLine}",
                       rollingInterval: RollingInterval.Day)))
                       // 写Information日志
                       .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Information).WriteTo.Async(config => config.File("Logs/info/log.txt",
                       outputTemplate: "{Timestamp:HH:mm} || {Level} || {SourceContext:l} || {Message} || end {NewLine}",
                       rollingInterval: RollingInterval.Day)))
                      .CreateLogger();
            #endregion
            try
            {
                var host = CreateHostBuilder(args).Build();

                #region EF自动迁移
                using (var scope = host.Services.CreateScope())
                {
                    var dbcontext = scope.ServiceProvider.GetRequiredService<GMPContext>();
                    var pendingMigrations = dbcontext.Database.GetPendingMigrations();
                    if (pendingMigrations.Any())
                    {
                        dbcontext.Database.Migrate();
                    }
                }
                #endregion

                host.Run();
            }
            catch(Exception ex) 
            {
                Log.Fatal(ex, "Host terminated unexpectedly!");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .UseSerilog(dispose: true);
    }
}
