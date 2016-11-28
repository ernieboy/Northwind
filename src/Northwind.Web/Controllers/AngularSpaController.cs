using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers
{
    public class AngularSpaController : BaseController
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}