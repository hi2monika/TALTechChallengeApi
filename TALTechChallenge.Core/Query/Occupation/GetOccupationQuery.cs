using AutoMapper;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using TALTechChallenge.Core.Common.Interfaces.Services;
using TALTechChallenge.Core.ViewModel;

namespace TALTechChallenge.Core.Query.Occupation
{
    public class GetOccupationQuery : IRequest<IEnumerable<OccupationViewModel>>
    { }

    public class GetOccupationQueryHandler : IRequestHandler<GetOccupationQuery, IEnumerable<OccupationViewModel>>
    {
        private readonly IOccupationRatingsRepository _occupationRatingsRepository;
        private readonly IMapper _mapper;

        public GetOccupationQueryHandler(IOccupationRatingsRepository occupationRatingsRepository, IMapper mapper)
        {
            _occupationRatingsRepository = occupationRatingsRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<OccupationViewModel>> Handle(GetOccupationQuery request, CancellationToken cancellationToken)
        {
            var occupations =  _occupationRatingsRepository.GetOccupation(cancellationToken);

            var occupationsResult =  occupations?.Any() ?? false
                ? _mapper.Map<IEnumerable<OccupationViewModel>>(occupations)
                : Enumerable.Empty<OccupationViewModel>();

            return await  Task.FromResult(occupationsResult);
        }
    }
}
