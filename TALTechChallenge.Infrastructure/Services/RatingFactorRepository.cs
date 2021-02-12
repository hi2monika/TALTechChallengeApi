using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using TALTechChallenge.Core.Common.Interfaces.Services;
using TALTechChallenge.Core.Models.Entities;

namespace TALTechChallenge.Infrastructure.Services
{
    public class RatingFactorRepository : IRatingFactorRepository
    {
        private readonly IReadOnlyList<RatingFactor> _ratingFactors;
        public RatingFactorRepository()
        {
            _ratingFactors = new List<RatingFactor>
            {
                new RatingFactor( "Light Manual",1.50),
                new RatingFactor("Professional",1.0),
                new RatingFactor("White Collar",1.25),
                new RatingFactor("Heavy Manual",1.25),

            };
        }
        public IReadOnlyList<RatingFactor> GetRatingFactor(CancellationToken cancellationToken)
        {
            return _ratingFactors;
        }

        public double? GetRatingFactorByRating(string rating, CancellationToken cancellationToken)
        {
            return _ratingFactors.Where(x => x.Rating.Equals(rating, StringComparison.InvariantCultureIgnoreCase)).FirstOrDefault()?.Factor;
        }
    }
}
