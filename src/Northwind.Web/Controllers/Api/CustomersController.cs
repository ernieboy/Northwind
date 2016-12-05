using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Data.Business;
using Core.Common.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Northwind.Models;

namespace Northwind.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public sealed class CustomersController : Controller
    {
        private readonly IEntityBusiness<Customer> _customerBusiness;

        public CustomersController(IEntityBusiness<Customer> customerBusiness )
        {
            _customerBusiness = customerBusiness;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> FindByStringId(string id)
        {
            var customer = await _customerBusiness.FindEntityByStringId(id);
            return Json(customer);
        }

        [HttpGet]
        [Route("")]
        public IActionResult List(  
            int? pageNumber, int? pageSize, string sortCol,
            string sortDir, string searchTerms)
        {

            OperationResult result = _customerBusiness.ListItems(
                pageNumber, pageSize, sortCol ?? "CustomerId", sortDir, searchTerms);


            var paginationData = new PaginationData
            {
                OffsetFromZero = (int)result.ObjectsDictionary["offset"],
                PageNumber = (int)result.ObjectsDictionary["pageIndex"],
                PageSize = (int)result.ObjectsDictionary["sizeOfPage"],
                OffsetUpperBound = (int)result.ObjectsDictionary["offsetUpperBound"],
                TotalNumberOfRecords = (int)result.ObjectsDictionary["totalNumberOfRecords"],
                TotalNumberOfPages = (int)result.ObjectsDictionary["totalNumberOfPages"],
                SearchTermsCommaSeparated = result.ObjectsDictionary["searchTerms"].ToString(),
                SortColumn = result.ObjectsDictionary["sortCol"].ToString(),
                SortDirection = result.ObjectsDictionary["sortDir"].ToString()
            };
            var list = result.ObjectsDictionary["list"] as IEnumerable<Customer>;
            var toReturn = Json(new { list, paginationData });

            return toReturn;
        }

    }
}