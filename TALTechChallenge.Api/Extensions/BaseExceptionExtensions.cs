using TALTechChallenge.Api.Model;
using TALTechChallenge.Core.Common.Exceptions;

namespace TALTechChallenge.Api.Extensions
{
    public static class BaseExceptionExtensions
    {
        public static ErrorResponseModel ToErrorResponseModel<TException>(this TException exception, string errorDescription = null)
          where TException : BaseException
        {
            var code = exception?.ErrorCode;
            var description = errorDescription ?? exception?.Message ?? string.Empty;

            return new ErrorResponseModel(code, description);
        }
    }
}
