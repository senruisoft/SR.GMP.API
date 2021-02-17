using System;
using System.IO;
using System.Linq;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using SR.GMP.EFCore;

namespace SR.GMP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            #region SeriLog����
            var LogRoot = Path.Combine(AppContext.BaseDirectory, "Logs/error/log.txt");
            Log.Logger = new LoggerConfiguration()
                      .MinimumLevel.Information()
                      .MinimumLevel.Override("Microsoft", LogEventLevel.Fatal)
                      .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning) // ����EF��־����
                      .Enrich.FromLogContext()
                      // дError��־
                      .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Error).WriteTo.Async(config => config.File(Path.Combine(AppContext.BaseDirectory, "Logs/error/log.txt"),
                       outputTemplate: "{Timestamp:HH:mm} || {Level} || {SourceContext:l} || {Message} || end {NewLine}",
                       rollingInterval: RollingInterval.Day)))
                       // дInformation��־
                       .WriteTo.Logger(lg => lg.Filter.ByIncludingOnly(p => p.Level == LogEventLevel.Information).WriteTo.Async(config => config.File(Path.Combine(AppContext.BaseDirectory, "Logs/info/log.txt"),
                       outputTemplate: "{Timestamp:HH:mm} || {Level} || {SourceContext:l} || {Message} || end {NewLine}",
                       rollingInterval: RollingInterval.Day)))
                      .CreateLogger();
            #endregion
            try
            {
                var host = CreateHostBuilder(args).Build();

                #region EF�Զ�Ǩ��
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
                Log.Error(ex, "Host terminated unexpectedly!");
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
