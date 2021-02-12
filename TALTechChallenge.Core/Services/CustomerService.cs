using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;
using TALTechChallenge.Core.Common.Exceptions;
using TALTechChallenge.Core.Common.Helper;
using TALTechChallenge.Core.Common.Interfaces.Services;

namespace TALTechChallenge.Core.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly ILogger<CustomerService> _logger;
        private readonly IRatingFactorRepository _ratingFactorRepository;
        private readonly IOccupationRatingsRepository _occupationRatingsRepository;


        public CustomerService(ILogger<CustomerService> logger, IRatingFactorRepository ratingFactorRepository, IOccupationRatingsRepository occupationRatingsRepository)
        {
            _logger = logger;
            _ratingFactorRepository = ratingFactorRepository;
            _occupationRatingsRepository = occupationRatingsRepository;
        }
        

        public async Task<double> CalculateMonthlyPremium(int age, double deathSumInsured, string occupation, CancellationToken cancellationToken)
        {
            
            var rating = _occupationRatingsRepository.GetOccupationRatingsByOccupation(occupation,  cancellationToken);
            
            if(rating == null)
            {
                throw new NotFoundException(Common.Constants.ErrorCodes.OccupationNotFound);
            }
            
            var factor = _ratingFactorRepository.GetRatingFactorByRating(rating, cancellationToken);

            if (factor == null)
            {
                throw new NotFoundException(Common.Constants.ErrorCodes.RatingNotFound);
            }
            var monthlyPremium = PremiumCalculatorHelper.CalcalatePremium(deathSumInsured, factor.Value, age);

            return await Task.FromResult(monthlyPremium);
        }
    }
}
