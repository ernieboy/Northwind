using Microsoft.Extensions.DependencyInjection;
using Core.Common.Data.Interfaces;
using Northwind.Models;
using Xunit;

namespace Northwind.UnitTests.DataAccess.CustomerRepository
{
    public class FindEntityByStringIdShould : BaseRepositoryTest
    {

        [Fact]
        public async void ReturnAnEntityThatExistsInTheRepository()
        {
            IDataRepository<Customer> repo = ServiceProvider.GetService<IDataRepository<Customer>>();
            Customer cust = await repo.FindEntityByStringId("ALFKI");
            Assert.True(cust != null);
        }

    }
}
