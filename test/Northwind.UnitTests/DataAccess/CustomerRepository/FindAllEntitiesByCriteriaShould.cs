using System.Collections.Generic;
using System.IO;
using System.Linq;
using Core.Common.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Northwind.DataAccess;
using Northwind.Models;
using Xunit;
using Microsoft.EntityFrameworkCore;

namespace Northwind.UnitTests.DataAccess.CustomerRepository
{
    public class FindAllEntitiesByCriteriaShould
    {
        private IConfigurationRoot _configuration;

        [Fact]
        public  void ReturnEntitiesWhenNoQueryFilterSpecified()
        {
            var builder = new ConfigurationBuilder()
                  .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .Build();
            _configuration = builder;

            var services = new ServiceCollection();
            services.AddDbContext<NorthwindSqliteDbContext>(options =>
            options.UseSqlite(_configuration.GetConnectionString("NorthwindConnection")));

            //Repositories services 
            services.AddScoped<IDataRepository<Customer>, Northwind.DataAccess.Repositories.CustomerRepository>();
            var serviceProvider = services.BuildServiceProvider();

            IDataRepository<Customer> repo = serviceProvider.GetService<IDataRepository<Customer>>();

            int totalRecords;

            IEnumerable<Customer> custs =  repo.FindAllEntitiesByCriteria(1, 10, out totalRecords, "CustomerID", "ASC", null);
            Customer[] customersArray = custs as Customer[] ?? custs.ToArray();
            Assert.True(customersArray.Any());
            Assert.True(customersArray.Length == 10);
        }
    }
}
