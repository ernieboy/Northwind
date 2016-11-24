using Northwind.DataAccess;
using Northwind.DataAccess.Repositories;
using Northwind.Models;
using Xunit;

namespace Northwind.UnitTests.DataAccess.CustomerRepository
{
    public class FindEntityByStringIdShould
    {

        //[Fact]
        public async void ReturnAnEntityThatExistsInTheRepository()
        {
            var context = new NorthwindSqliteDbContext();
            ICustomerRepository repo = new Northwind.DataAccess.Repositories.CustomerRepository(context);
            Customer cust = await repo.FindEntityByStringId("ALFKI");
            Assert.True(cust != null);
        }

    }
}
