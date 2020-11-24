using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Blog.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("Error/{code}")]
        public IActionResult Error(int code)
        {
            ViewBag.Code = code;
            return View();
        }

        [AllowAnonymous]
        [Route("Exception")]
        public IActionResult Exception()
        {
            var exeptionDetails = HttpContext.Features.Get<IExceptionHandlerPathFeature>();
            _logger.LogError($"{exeptionDetails.Path}");
            _logger.LogError($"{exeptionDetails.Error.Message}");
            _logger.LogError($"{exeptionDetails.Error.StackTrace}");
            ViewBag.Path = exeptionDetails.Path;
            ViewBag.Message = exeptionDetails.Error.Message;
            ViewBag.StackTrace = exeptionDetails.Error.StackTrace;
            return View();
        }
    }
}
