using System.Collections.Generic;
using System.Linq;
using Core.Common.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Northwind.Models;
using Xunit;

namespace Northwind.UnitTests.DataAccess.CustomerRepository
{
    public class FindAllEntitiesByCriteriaShould : TestBase
    {
        private readonly ILogger _logger;

        public FindAllEntitiesByCriteriaShould()
        {
            _logger = LoggerFactory.CreateLogger<FindAllEntitiesByCriteriaShould>();
        }

        [Fact]
        public void ReturnEntitiesWhenNoQueryFilterSpecified()
        {
            _logger.LogInformation("WECOME TO ReturnEntitiesWhenNoQueryFilterSpecified!!");
            IDataRepository<Customer> repo = ServiceProvider.GetService<IDataRepository<Customer>>();

            int totalRecords;
            IEnumerable<Customer> custs = repo.FindAllEntitiesByCriteria(1, 10, out totalRecords, "CustomerID", "ASC", null);
            Customer[] customersArray = custs as Customer[] ?? custs.ToArray();
            Assert.True(customersArray.Any());
            Assert.True(customersArray.Length == 10);
        }
    }
}
