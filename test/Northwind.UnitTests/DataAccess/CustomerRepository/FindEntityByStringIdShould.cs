using Microsoft.Extensions.DependencyInjection;
using Core.Common.Data.Interfaces;
using Microsoft.Extensions.Logging;
using Northwind.Models;
using Xunit;

namespace Northwind.UnitTests.DataAccess.CustomerRepository
{
    public class FindEntityByStringIdShould : TestBase
    {
        private readonly ILogger _logger ;

        public FindEntityByStringIdShould()
        {
            _logger = LoggerFactory.CreateLogger<FindEntityByStringIdShould>();
        }



        [Fact]
        public async void ReturnAnEntityThatExistsInTheRepository()
        {
            _logger.LogInformation("WECOME TO ReturnAnEntityThatExistsInTheRepository!!");
            IDataRepository<Customer> repo = ServiceProvider.GetService<IDataRepository<Customer>>();
            Customer cust = await repo.FindEntityByStringId("ALFKI");
            Assert.True(cust != null);
        }

    }
}
