using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SR.GMP.API.Filter;
using SR.GMP.EFCore;
using SR.GMP.Infrastructure.Repositories;
using SR.GMP.Infrastructure.UnitOfWork;

namespace SR.GMP.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            // ���ù�����
            services.AddMvc(mvcOptions =>
            {
                mvcOptions.Filters.Add<GlobalExceptionFilterAttribute>();
                mvcOptions.Filters.Add<GlobalResultFilterAttribute>();
            });

            #region swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("GMP", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GMP API", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var xmlPath_Service = Path.Combine(AppContext.BaseDirectory, "SR.GMP.Service.Contracts.xml");
                c.IncludeXmlComments(xmlPath);
                c.IncludeXmlComments(xmlPath_Service);
            });
            #endregion

            // �������ݿ�����������
            services.AddDbContext<GMPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GMPContext")));

            // ����AutoMapper
            services.AddAutoMapper(Assembly.Load("SR.GMP.Service.Contracts"));
        }

        /// <summary>
        /// AutoFac����
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            //var controllerBaseType = typeof(ControllerBase);
            //builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            //    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            //    .PropertiesAutowired();

            // ע��Ӧ�÷���
            builder.RegisterAssemblyTypes(Assembly.Load("SR.GMP.Service")).Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces();
            // ע��ִ�
            builder.RegisterAssemblyTypes(Assembly.Load("SR.GMP.Infrastructure")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>(); // ע�Ṥ����Ԫ
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerDependency(); //ע��ִ�����
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            #region swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/GMP/swagger.json", "GMP API");
                c.RoutePrefix = string.Empty;
            });
            #endregion

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
