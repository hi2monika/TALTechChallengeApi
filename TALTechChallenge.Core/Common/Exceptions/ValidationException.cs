namespace TALTechChallenge.Core.Common.Exceptions
{
    public class ValidationException : BaseException
    {
        public ValidationException(string errorCode, string errorMessage) : base(errorCode, errorMessage)
        {
        }
    }
}
