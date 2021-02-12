using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TALTechChallenge.Core.Common.Interfaces.Services;
using TALTechChallenge.Core.Models.Entities;

namespace TALTechChallenge.Infrastructure.Services
{
    public class OccupationRatingsRepository : IOccupationRatingsRepository
    {
        private readonly IReadOnlyList<OccupationRatings> _occupationRatings;
        public OccupationRatingsRepository()
        {
            _occupationRatings = new List<OccupationRatings>
            {
                new OccupationRatings("Cleaner", "Light Manual"),
                new OccupationRatings("Doctor", "Professional"),
                new OccupationRatings("Author", "White Collar"),
                new OccupationRatings("Farmer", "Heavy Manual"),
                new OccupationRatings("Mechanic", "Heavy Manual"),
                new OccupationRatings("Florist", "Light Manual"),

            };
        }

        public IReadOnlyList<Occupations> GetOccupation(CancellationToken cancellationToken)
        {
            // Note : purpose of this class (Occupations) to demo the mapper funcationality .It canbe simplited by just restuning string .
            return _occupationRatings.Select(x => new Occupations( x.Occupation)).Distinct().ToList();
        }

        public IReadOnlyList<OccupationRatings> GetOccupationRatings(CancellationToken cancellationToken)
        {
            return _occupationRatings;
        }

        public string GetOccupationRatingsByOccupation(string occupation, CancellationToken cancellationToken)
        {
           return _occupationRatings.Where(x => x.Occupation.Equals(occupation, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault()?.Rating;
        }
    }
}
