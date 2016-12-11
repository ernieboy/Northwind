using Microsoft.Extensions.DependencyInjection;
using Core.Common.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Northwind.Models;
using Xunit;

namespace Northwind.UnitTests.DataAccess.EmployeeRepository
{
    public class FindEntityByIdShould : TestBase
    {
        private readonly ILogger _logger;

        public FindEntityByIdShould()
        {
            _logger = LoggerFactory.CreateLogger<FindEntityByIdShould>();
        }

        [Fact]
        public async void ReturnAnEntityThatExistsInTheRepository()
        {
            _logger.LogInformation("WECOME TO ReturnAnEntityThatExistsInTheRepository!!");
            IDataRepository<Employee> repo = ServiceProvider.GetService<IDataRepository<Employee>>();
            Employee employee = await repo.FindEntityById(2);
            Assert.True(employee != null);
        }
    }
}
