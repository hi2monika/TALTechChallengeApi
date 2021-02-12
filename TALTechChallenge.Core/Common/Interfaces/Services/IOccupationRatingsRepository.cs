using System.Collections.Generic;
using System.Threading;
using TALTechChallenge.Core.Models.Entities;

namespace TALTechChallenge.Core.Common.Interfaces.Services
{
    public interface IOccupationRatingsRepository
    {
        IReadOnlyList<OccupationRatings> GetOccupationRatings(CancellationToken cancellationToken);
        IReadOnlyList<Occupations> GetOccupation(CancellationToken cancellationToken);
        string GetOccupationRatingsByOccupation(string occupation, CancellationToken cancellationToken);

    }
}
