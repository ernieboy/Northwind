using System.Collections.Generic;
using System.Linq;
using Core.Common.Data.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Northwind.Models;
using Xunit;

namespace Northwind.UnitTests.DataAccess.EmployeeRepository
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
            IDataRepository<Employee> repo = ServiceProvider.GetService<IDataRepository<Employee>>();

            int totalRecords;
            IEnumerable<Employee> employees = repo.FindAllEntitiesByCriteria(1, 10, out totalRecords, "EmployeeID", "ASC", null);
            Employee[] employeesArray = employees as Employee[] ?? employees.ToArray();
            Assert.True(employeesArray.Any());
            Assert.True(employeesArray.Length > 1);
        }

    }
}
