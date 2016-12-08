using Microsoft.AspNetCore.Mvc;

namespace Northwind.Web.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}