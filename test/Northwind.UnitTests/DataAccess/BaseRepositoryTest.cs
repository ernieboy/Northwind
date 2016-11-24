using System;
using System.IO;
using Core.Common.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.DataAccess;
using Northwind.Models;
using Microsoft.EntityFrameworkCore;

namespace Northwind.UnitTests.DataAccess
{
    public abstract class BaseRepositoryTest
    {
        protected BaseRepositoryTest()
        {
            SetUp();
        }
        protected IConfigurationRoot Configuration;
        protected IServiceProvider ServiceProvider;

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

            //Repositories services 
            services.AddScoped<IDataRepository<Customer>, Northwind.DataAccess.Repositories.CustomerRepository>();
            ServiceProvider = services.BuildServiceProvider();
        }
    }
}
