using System;

namespace TALTechChallenge.Core.Common.Exceptions
{
    public abstract class BaseException : Exception
    {
        public string ErrorCode { get; }

        protected BaseException(string errorCode, string errorMessage) : base(errorMessage)
        {
            ErrorCode = errorCode;
        }
    }
}
