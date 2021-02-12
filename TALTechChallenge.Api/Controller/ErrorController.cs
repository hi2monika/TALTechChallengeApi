using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Net;
using TALTechChallenge.Api.Extensions;
using TALTechChallenge.Api.Model;
using TALTechChallenge.Core.Common.Exceptions;

namespace TALTechChallenge.Api.Controller
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        private readonly ILogger<ErrorController> _logger;

        public ErrorController(ILogger<ErrorController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            _logger.LogError(exception, $"Handing unhandled exception of type {exception?.GetType().Name}");

            switch (exception)
            {
                case ValidationException validationException:
                case NotFoundException notFoundException:
                case EmptyRequestException emptyRequestException:
                    var errorResponseModel = (exception as BaseException).ToErrorResponseModel();
                    return new BadRequestObjectResult(errorResponseModel);

                // TODO More custom can be added

                default:
                    return new ObjectResult(new ErrorResponseModel(HttpStatusCode.InternalServerError.ToString(), "Unhandled Exception"));
            }
        }

        [Route("/error-local-development")]
        public IActionResult ErrorLocalDevelopment()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context?.Error;

            return Problem(exception?.StackTrace, title: exception?.Message);
        }
    }
}
