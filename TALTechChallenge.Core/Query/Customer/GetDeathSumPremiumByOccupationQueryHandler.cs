using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TALTechChallenge.Core.Common.Interfaces.Services;

namespace TALTechChallenge.Core.Query.Customer
{
    public class GetDeathSumPremiumByOccupationQueryHandler : IRequestHandler<GetDeathSumPremiumByOccupationQuery, double>
    {

        private readonly ILogger<GetDeathSumPremiumByOccupationQueryHandler> _logger;
        private readonly ICustomerService _customerService;
        public GetDeathSumPremiumByOccupationQueryHandler(ICustomerService customerService, ILogger<GetDeathSumPremiumByOccupationQueryHandler> logger)
        {
            _logger = logger;
            _customerService = customerService;
        }
        public async Task<double> Handle(GetDeathSumPremiumByOccupationQuery request, CancellationToken cancellationToken)
        {
            var parsedAge = int.Parse(request.Age);
            var parsedDeathSumInsured = double.Parse(request.DeathSumInsured);

            return await _customerService.CalculateMonthlyPremium(parsedAge, parsedDeathSumInsured, request.Occupation, cancellationToken);
        }

    }
}
