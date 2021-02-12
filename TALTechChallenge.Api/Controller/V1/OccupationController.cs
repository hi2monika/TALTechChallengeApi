using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.Swagger.Annotations;
using System.Collections.Generic;
using System.Threading.Tasks;
using TALTechChallenge.Api.Common;
using TALTechChallenge.Api.Model;
using TALTechChallenge.Core.Query.Occupation;
using TALTechChallenge.Core.ViewModel;

namespace TALTechChallenge.Api.Controller.V1
{
    [Route("api/[controller]")]
    [ApiController]
    public class OccupationController : ApiController
    {
        public OccupationController(IMediator mediator)
            : base(mediator)
        {
        }
        /// <summary>
        ///  Get a list of Occupation
        /// </summary>
        /// <returns>Occupation List</returns>
        [HttpGet]
        [SwaggerResponse(200, ApiResponseMessages.SuccessfulOperation, typeof(IEnumerable<OccupationViewModel>))]
        [SwaggerResponse(401, ApiResponseMessages.Unauthorized, typeof(ErrorResponseModel))]
        [SwaggerResponse(500, ApiResponseMessages.InternalServerError, typeof(ErrorResponseModel))]
        public async Task<IEnumerable<OccupationViewModel>> GetOccupation()
        {
            var request = new GetOccupationQuery();
            return await Mediator.Send(request);
        }
    }
}
