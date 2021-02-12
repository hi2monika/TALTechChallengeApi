using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TALTechChallenge.Api.Common;
using TALTechChallenge.Api.Model;
using TALTechChallenge.Core.Query.Customer;

namespace TALTechChallenge.Api.Controller.V1
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class CalculationController : ApiController
    {
        public CalculationController(IMediator mediator)
            : base(mediator)
        {
        }        

        [HttpGet]
        [Route("CalculatePremium")]
        [SwaggerResponse(200, ApiResponseMessages.SuccessfulOperation, typeof(double))]
        [SwaggerResponse(401, ApiResponseMessages.Unauthorized, typeof(ErrorResponseModel))]
        [SwaggerResponse(404, ApiResponseMessages.NotFound, typeof(ErrorResponseModel))]
        [SwaggerResponse(500, ApiResponseMessages.InternalServerError, typeof(ErrorResponseModel))]
        public async Task<double> CalculatePremium(string age, string deathSumInsured, string Occupation)
        {
            return await Mediator.Send(new GetDeathSumPremiumByOccupationQuery(age, deathSumInsured, Occupation));

        }
    }    
 
}
