using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Autofac;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Panda.DynamicWebApi;
using SR.GMP.API.Filter;
using SR.GMP.Common.Resolver;
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

            // 配置跨域处理，允许所有来源
            services.AddCors(options => options.AddPolicy("cors", p => p.AllowAnyHeader().AllowAnyMethod()
            .SetIsOriginAllowed(_ => true).AllowCredentials()));

            // 配置动态Api
            services.AddDynamicWebApi(options =>
            {
                options.RemoveControllerPostfixes.Add("Service");
            });

            // 配置过滤器
            services.AddMvc(mvcOptions =>
            {
                mvcOptions.Filters.Add<LogFilterAttribute>();
                mvcOptions.Filters.Add<ModelValidFilterAttribute>();
                mvcOptions.Filters.Add<GlobalExceptionFilterAttribute>();
                mvcOptions.Filters.Add<GlobalResultFilterAttribute>();
            }).AddNewtonsoftJson(options => 
            {
                // 配置返回参数小写
                options.SerializerSettings.ContractResolver = new LowercaseContractResolver();
            });

            #region swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("GMP", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "GMP API", Version = "v1" });
                options.DocInclusionPredicate((docName, description) => true);
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                var xmlPath_Service = Path.Combine(AppContext.BaseDirectory, "SR.GMP.Service.xml");
                var xmlPath_Service_Contracts = Path.Combine(AppContext.BaseDirectory, "SR.GMP.Service.Contracts.xml");
                options.IncludeXmlComments(xmlPath);
                options.IncludeXmlComments(xmlPath_Service);
                options.IncludeXmlComments(xmlPath_Service_Contracts);
            });
            #endregion

            // 配置数据库上下文连接
            services.AddDbContext<GMPContext>(options => options.UseSqlServer(Configuration.GetConnectionString("GMPContext")));

            // 配置AutoMapper
            services.AddAutoMapper(Assembly.Load("SR.GMP.Service.Contracts"));
        }

        /// <summary>
        /// AutoFac配置
        /// </summary>
        /// <param name="builder"></param>
        public void ConfigureContainer(ContainerBuilder builder)
        {

            //var controllerBaseType = typeof(ControllerBase);
            //builder.RegisterAssemblyTypes(typeof(Program).Assembly)
            //    .Where(t => controllerBaseType.IsAssignableFrom(t) && t != controllerBaseType)
            //    .PropertiesAutowired();

            // 注册应用服务
            builder.RegisterAssemblyTypes(Assembly.Load("SR.GMP.Service")).Where(a => a.Name.EndsWith("Service")).AsImplementedInterfaces();
            // 注册仓储
            builder.RegisterAssemblyTypes(Assembly.Load("SR.GMP.Infrastructure")).Where(a => a.Name.EndsWith("Repository")).AsImplementedInterfaces();
            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>(); // 注册工作单元
            builder.RegisterGeneric(typeof(Repository<,>)).As(typeof(IRepository<,>)).InstancePerDependency(); //注册仓储泛型
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // 允许所有跨域，cors是在ConfigureServices方法中配置的跨域策略名称
            app.UseCors("cors");

            app.UseHttpsRedirection();

            app.UseRouting();

            // 读取Request的Body流
            app.Use(next => context =>
            {
                context.Request.EnableBuffering();
                return next(context);
            });

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
