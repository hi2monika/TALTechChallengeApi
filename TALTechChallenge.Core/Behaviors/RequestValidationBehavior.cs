using FluentValidation;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ValidationException = TALTechChallenge.Core.Common.Exceptions.ValidationException;

namespace TALTechChallenge.Core.Behaviors
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
     where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            if (!_validators.Any())
            {
                return next();
            }

            var context = new ValidationContext<TRequest>(request); 

            var failures = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(validationFailure => validationFailure != null)
                .ToList();

            if (!failures.Any())
            {
                return next();
            }

            var firstFailure = failures.First();
            throw new ValidationException(firstFailure.ErrorCode, firstFailure.ErrorMessage);
        }
    }
}
