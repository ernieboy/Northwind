using System;
using System.IO;
using Core.Common.Data.Business;
using Core.Common.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.DataAccess;
using Northwind.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Northwind.Business;
using Serilog;

namespace Northwind.UnitTests.DataAccess
{
    public abstract class TestBase      
    {
        private Microsoft.Extensions.Logging.ILogger _logger;

        protected TestBase()
        {
            SetUp();
        }

        protected IConfigurationRoot Configuration;
        protected IServiceProvider ServiceProvider;
        protected ILoggerFactory LoggerFactory;   

        private void SetUp()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            Configuration = builder;

            var services = new ServiceCollection();
            services.AddDbContext<NorthwindSqliteDbContext>(options =>
                options.UseSqlite(Configuration.GetConnectionString("NorthwindConnection")));

            Log.Logger = new LoggerConfiguration().ReadFrom.Configuration(Configuration)
           //     .MinimumLevel.Debug()
             //   .WriteTo.RollingFile(Path.Combine(@"C:\data\logs", "log-{Date}.txt"))
                .CreateLogger();

            LoggerFactory = new LoggerFactory();
            LoggerFactory.AddSerilog();

            _logger = LoggerFactory.CreateLogger<TestBase>();

            //Repositories services 
            services.AddScoped<IDataRepository<Customer>, Northwind.DataAccess.Repositories.CustomerRepository>();
           

            //Business services
            services.AddScoped<IEntityBusiness<Customer>, CustomerBusiness>();

            //Note, make sure this line comes after all services have been added to the DI System.
            ServiceProvider = services.BuildServiceProvider();




        }
    }
}
