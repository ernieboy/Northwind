﻿using System.IO;
using Core.Common.Data.Business;
using Core.Common.Data.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Logging;
using Northwind.Business;
using Northwind.DataAccess;
using Northwind.Models;
using Northwind.Web.Data;
using Northwind.Web.Models;
using Northwind.Web.Services;
using Serilog;

namespace Northwind.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsDevelopment())
            {
                // For more details on using the user secret store see http://go.microsoft.com/fwlink/?LinkID=532709
                builder.AddUserSecrets();

                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddDbContext<NorthwindSqliteDbContext>(options =>
               options.UseSqlite(Configuration.GetConnectionString("NorthwindConnection")));
            services.AddDbContext<ApplicationDbContext>(options =>
              options.UseSqlite(Configuration.GetConnectionString("NorthwindConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddMemoryCache();
            services.AddSession();

            services.AddMvc();

            // Add application services.
            services.AddTransient<IEmailSender, AuthMessageSender>();
            services.AddTransient<ISmsSender, AuthMessageSender>();

            //Repositories services 
            services.AddScoped<IDataRepository<Customer>, DataAccess.Repositories.CustomerRepository>();
            services.AddScoped<IDataRepository<Employee>, DataAccess.Repositories.EmployeeRepository>();

            //Business services
            services.AddScoped<IEntityBusiness<Customer>, CustomerBusiness>();
            services.AddScoped<IEntityBusiness<Employee>, EmployeeBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //   loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            //  loggerFactory.AddDebug();

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration)
              //     .MinimumLevel.Debug()
              //   .WriteTo.RollingFile(Path.Combine(@"C:\data\logs", "log-{Date}.txt"))
              .CreateLogger();
            loggerFactory.AddSerilog();

            app.UseApplicationInsightsRequestTelemetry();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
                app.UseBrowserLink();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseStaticFiles();

            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(
            Path.Combine(Directory.GetCurrentDirectory(), @"node_modules")),
                RequestPath = new PathString("/node_modules")
            });

            app.UseSession();

            app.UseIdentity();

            // Add external authentication middleware below. To configure them please see http://go.microsoft.com/fwlink/?LinkID=532715

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
                routes.MapSpaFallbackRoute(
                     name: "spa-fallback",
                     defaults: new { controller = "AngularSpa", action = "Index" });
            });
        }
    }
}
