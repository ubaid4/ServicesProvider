using AuthJwt.UI.Controllers;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesProvider.Core.DTOs.Shared;

namespace ServicesProvider.UI.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : BaseController
    {
        private readonly ILogger<ErrorController> _logger;  
        public ErrorController(ILogger<ErrorController> logger) { 
            _logger = logger;
        
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            string ErrorMsg=context.Error.Message.ToString();
            _logger.LogError("Error occured"+ ErrorMsg);
           
            return Problem("Something went wrong on server side: " +ErrorMsg);
        }
    }
}
