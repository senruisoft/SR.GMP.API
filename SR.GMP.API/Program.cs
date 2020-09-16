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
using SR.GMP.EFCore;

namespace SR.GMP.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            #region EF×Ô¶¯Ç¨ÒÆ
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

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                })
                .UseServiceProviderFactory(new AutofacServiceProviderFactory());
    }
}
