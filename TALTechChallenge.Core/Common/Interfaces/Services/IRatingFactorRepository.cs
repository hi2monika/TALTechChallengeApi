using System.Collections.Generic;
using System.Threading;
using TALTechChallenge.Core.Models.Entities;

namespace TALTechChallenge.Core.Common.Interfaces.Services
{
    public interface IRatingFactorRepository
    {
        IReadOnlyList<RatingFactor> GetRatingFactor(CancellationToken cancellationToken);

        double? GetRatingFactorByRating(string rating, CancellationToken cancellationToken);
    }
}
