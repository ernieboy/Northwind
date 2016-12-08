using Core.Common.Data.Business;
using Northwind.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Xunit;

namespace Northwind.UnitTests.Business.EmployeeBusiness
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
            IEntityBusiness<Employee> employeeBusiness = ServiceProvider.GetService<IEntityBusiness<Employee>>();
            Employee employee = await employeeBusiness.FindEntityById(2);
            Assert.True(employee != null);
        }
    }
}
