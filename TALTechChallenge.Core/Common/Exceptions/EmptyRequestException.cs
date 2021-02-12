namespace TALTechChallenge.Core.Common.Exceptions
{
    public class EmptyRequestException : BaseException
    {
        public EmptyRequestException(string errorCode) : base(errorCode, Constants.ValidatorMessages.EmptyBodyRequest)
        {
        }
    }
}
