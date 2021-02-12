using MediatR;
using Microsoft.Extensions.Logging;
using System.Threading;
using System.Threading.Tasks;

namespace TALTechChallenge.Core.Command
{
    //TODO : Show case how to handle command ,Demo purpose only
    public class CreateCommandHandler : IRequestHandler<CreateCommand, string>
    {
        
        private readonly ILogger<CreateCommandHandler> _logger;
        public CreateCommandHandler(ILogger<CreateCommandHandler> logger)
        {
            
            _logger = logger;
        }
        public async Task<string>  Handle(CreateCommand request, CancellationToken cancellationToken)
        {
            return await Task.FromResult("Test");
        }
    }
}
