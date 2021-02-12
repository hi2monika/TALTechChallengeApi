using MediatR;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace TALTechChallenge.Core.Behaviors
{
    public class RequestPerformanceBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    {
        private const long PerformanceThreshold = 500;

        private const string RequestPerformanceLogMessage =
            "API Long Running Request: {Name} ({ElapsedMilliseconds} milliseconds) {@Request}";

        private readonly ILogger<TRequest> _logger;
        private readonly Stopwatch _timer;

        public RequestPerformanceBehaviour(ILogger<TRequest> logger)
        {
            _timer = new Stopwatch();
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken,
            RequestHandlerDelegate<TResponse> next)
        {
            _timer.Start();

            var response = await next();

            _timer.Stop();

            var elapsedMilliseconds = _timer.ElapsedMilliseconds;

            if (elapsedMilliseconds <= PerformanceThreshold)
            {
                return response;
            }

            var requestName = typeof(TRequest).Name;

            _logger.LogInformation(RequestPerformanceLogMessage, requestName, elapsedMilliseconds, request);

            return response;
        }
    }
}
