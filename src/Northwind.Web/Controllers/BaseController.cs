using System;
using System.Text;
using System.Threading.Tasks;
using Core.Common.Utilities;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Northwind.Web.Controllers
{
    public abstract class BaseController : Controller
    {
        protected IHostingEnvironment hostingEnvironment;
        protected ILoggerFactory LoggerFactory;

        private readonly ILogger<BaseController> _logger;

        protected BaseController()
        {
        }

        protected BaseController(ILoggerFactory loggerFactory)
        {
            LoggerFactory = loggerFactory;
            _logger = LoggerFactory.CreateLogger<BaseController>();
        }

        ///Accepts a delegate of type IActionResult and invokes it. A IAction result is then returned.
        ///Sibbling Controller classes which return a IActionResult should wrap all their body code in this method so that all controller exceptions can be handled in one central place: here. There should not                       
        protected IActionResult ExecuteExceptionsHandledActionResult(Func<IActionResult> codeToExecute)
        {
            try
            {
                IActionResult result = codeToExecute.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                string error = Error.BuildExceptionDetail(ex, new StringBuilder()).ToString();
                _logger.LogError(error);
            }
            return View();
        }

        ///Accepts a delegate of type Task<IActionResult> and invokes it. A IAction result is then returned.
        ///Sibbling Controller classes which return a Task<IActionResult> should wrap all their body code in this method so that all controller exceptions can be handled in one central place: here. There should not                       
        protected async Task<IActionResult> ExecuteExceptionsHandledAsyncActionResult(Func<Task<IActionResult>> codeToExecute)
        {
            try
            {
                IActionResult result = await codeToExecute.Invoke();
                return result;
            }
            catch (Exception ex)
            {
                string error = Error.BuildExceptionDetail(ex, new StringBuilder()).ToString();
                _logger.LogError(error);
            }
            return View();
        }
    }
}