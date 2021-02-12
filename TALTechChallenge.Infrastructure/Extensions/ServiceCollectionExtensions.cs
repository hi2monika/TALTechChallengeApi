using Microsoft.Extensions.DependencyInjection;
using TALTechChallenge.Core.Common.Interfaces.Services;
using TALTechChallenge.Infrastructure.Services;

namespace TALTechChallenge.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection)
        {

            serviceCollection.AddScoped<IOccupationRatingsRepository, OccupationRatingsRepository>();
            serviceCollection.AddScoped<IRatingFactorRepository, RatingFactorRepository>();

            return serviceCollection;
        }
    }
}
