using System.Collections.Generic;
using System.Linq;
using Core.Common.Data.Business;
using Core.Common.Data.Models;
using Northwind.Models;
using Northwind.UnitTests.DataAccess;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Northwind.UnitTests.Business.CustomerBusiness
{
    public class ListItemsShould : BaseTest
    {

        [Fact]
        public void ReturnEntitiesWhenPresentInDatabase()
        {

            IEntityBusiness<Customer> cutomerBusiness = ServiceProvider.GetService<IEntityBusiness<Customer>>();
            int? pageSize = 10;
            string sortCol = "CustomerID";
            string sortDir = "ASC";
            string searchTerms = string.Empty;
            int? pageNumber = 1;
            OperationResult result = cutomerBusiness.ListItems(
                pageNumber, pageSize, sortCol, sortDir, searchTerms);

            Assert.True(result.Success);
            var list = result.ObjectsDictionary["list"] as IEnumerable<Customer>;
            Assert.True(list.Count() == pageSize);

        }
    }
}
