using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Common.Data.Business;
using Core.Common.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Business;
using Northwind.Models;

namespace Northwind.Web.Controllers.Api
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public sealed class EmployeesController : BaseApiController
    {
        private readonly IEntityBusiness<Employee> _employeeBusiness;

        public EmployeesController(IEntityBusiness<Employee> employeeBusiness,
           ILoggerFactory loggerFactory) : base(loggerFactory)
        {
            _employeeBusiness = employeeBusiness;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> FindById(int id)
        {
            return await ExecuteExceptionsHandledAsyncActionResult(async () =>
            {
                var employee = await _employeeBusiness.FindEntityById(id);
                return Json(employee);
            });
        }

        [HttpGet]
        [Route("")]
        public IActionResult List(
            int? pageNumber, int? pageSize, string sortCol,
            string sortDir, string searchTerms)
        {
            return ExecuteExceptionsHandledActionResult(() =>
            {
                OperationResult result = _employeeBusiness.ListItems(
                  pageNumber, pageSize, sortCol ?? "EmployeeId", sortDir, searchTerms);

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
                var list = result.ObjectsDictionary["list"] as IEnumerable<Employee>;
                var toReturn = Json(new { list, paginationData });

                return toReturn;
            });
        }
    }
}
