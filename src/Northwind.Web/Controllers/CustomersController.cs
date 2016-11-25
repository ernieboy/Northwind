using System.Collections.Generic;
using Core.Common.Data.Business;
using Core.Common.Data.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Northwind.Models;
using Northwind.Web.ViewModels;

namespace Northwind.Web.Controllers
{
    public class CustomersController : BaseController
    {
        private readonly IEntityBusiness<Customer> _customerEntityBusiness;
        private readonly ILogger<CustomersController> _logger;
        

        public CustomersController(
             IEntityBusiness<Customer> customerEntityBusiness,
             IHostingEnvironment hostingEnvironment,
             ILogger<CustomersController> logger)
        {
            _customerEntityBusiness = customerEntityBusiness;
            this.hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }



        public IActionResult Index(
            int? pageNumber, int? pageSize, string sortCol,
            string sortDir, string searchTerms)
        {
            return ExecuteExceptionsHandledActionResult(() =>
            {
                OperationResult result = _customerEntityBusiness.ListItems(
                pageNumber, pageSize, sortCol ?? "CustomerId", sortDir, searchTerms);

                ViewBag.offset = result.ObjectsDictionary["offset"];
                ViewBag.pageIndex = result.ObjectsDictionary["pageIndex"];
                ViewBag.sizeOfPage = result.ObjectsDictionary["sizeOfPage"];
                ViewBag.offsetUpperBound = result.ObjectsDictionary["offsetUpperBound"];
                ViewBag.totalRecords = result.ObjectsDictionary["totalNumberOfRecords"];
                ViewBag.totalNumberOfPages = result.ObjectsDictionary["totalNumberOfPages"];
                ViewBag.searchTerms = result.ObjectsDictionary["searchTerms"];
                ViewBag.sortCol = result.ObjectsDictionary["sortCol"];
                ViewBag.sortDir = result.ObjectsDictionary["sortDir"];

                var model = new CustomerListingViewModel { CustomersList = result.ObjectsDictionary["list"] as IEnumerable<Customer> };

                return View(model);
            });
        }
    }
}