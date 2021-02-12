using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TALTechChallenge.Api.Controller
{
    [ApiController]
    [Route("api/V1/[controller]")]
    public abstract class ApiController : ControllerBase
    {
        protected ApiController(IMediator mediator)
        {
            Mediator = mediator;
        }

        protected IMediator Mediator { get; }

        protected IEnumerable<string> GetAuthorizedResourceFromContext(string resourceKey)
        {
            if (HttpContext?.Items == null
                || !HttpContext.Items.TryGetValue(resourceKey,
                    out var authorizedResource)
                || !(authorizedResource is IEnumerable<string>))
            {
                return null;
            }

            return (IEnumerable<string>)authorizedResource;
        }
    }
}
