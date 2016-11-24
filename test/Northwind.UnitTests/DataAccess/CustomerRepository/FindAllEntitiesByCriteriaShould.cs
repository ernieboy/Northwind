using System.Collections.Generic;
using System.Linq;
using Northwind.DataAccess;
using Northwind.DataAccess.Repositories;
using Northwind.Models;
using Xunit;

namespace Northwind.UnitTests.DataAccess.CustomerRepository
{
    public class FindAllEntitiesByCriteriaShould
    {

        [Fact]
        public  void ReturnEntitiesWhenNoQueryFilterSpecified()
        {
            var context = new NorthwindSqliteDbContext();
            ICustomerRepository repo = new Northwind.DataAccess.Repositories.CustomerRepository(context);

            int totalRecords;

            IEnumerable<Customer> custs =  repo.FindAllEntitiesByCriteria(1, 10, out totalRecords, "CustomerID", "ASC", null);
            Customer[] customersArray = custs as Customer[] ?? custs.ToArray();
            Assert.True(customersArray.Any());
            Assert.True(customersArray.Length == 10);
        }
    }
}
