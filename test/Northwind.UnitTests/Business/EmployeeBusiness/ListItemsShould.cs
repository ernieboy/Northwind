using System.Collections.Generic;
using System.Linq;
using Core.Common.Data.Business;
using Core.Common.Data.Models;
using Northwind.Models;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace Northwind.UnitTests.Business.EmployeeBusiness
{
    public class ListItemsShould: TestBase
    {

        [Fact]
        public void ReturnEntitiesWhenPresentInDatabase()
        {
            IEntityBusiness<Employee> employeeBusiness = ServiceProvider.GetService<IEntityBusiness<Employee>>();
            int? pageSize = 10;
            string sortCol = "EmployeeID";
            string sortDir = "ASC";
            string searchTerms = string.Empty;
            int? pageNumber = 1;
            OperationResult result = employeeBusiness.ListItems(
                pageNumber, pageSize, sortCol, sortDir, searchTerms);

            Assert.True(result.Success);
            IEnumerable<Employee> list = result.ObjectsDictionary["list"] as IEnumerable<Employee>;
            Assert.True(list.Count() > 1);

        }
    }
}
