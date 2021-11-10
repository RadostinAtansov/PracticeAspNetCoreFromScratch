
namespace PracticeAspNetCoreWithKunvenkat.Controllers
{
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Components.Routing;
    using Microsoft.AspNetCore.Diagnostics;
    using Microsoft.AspNetCore.Mvc;

    public class ErrorController : Controller
    {
        [Route("Error/{statusCode}")]
        public IActionResult HttpStatusCodeHandler(int statusCode)
        {
            switch(statusCode)
            {
                case 404:
                    ViewBag.ErrorMessage = "Sory, the page could not be found";
                    break;
            }
            return View("NotFound");
        }


        [AllowAnonymous]
        [Route("Error")]
        public IActionResult Error()
        {
            var exceptionHandlerPathFeature = HttpContext.Features.Get<IExceptionHandlerPathFeature>();

            ViewBag.ExceptionPath = exceptionHandlerPathFeature.Path;
            ViewBag.ExceptionMessage = exceptionHandlerPathFeature.Error.Message;
            ViewBag.StackTrace = exceptionHandlerPathFeature.Error.StackTrace;

            return View("Error");

        }
    }
}
