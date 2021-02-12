using System;
using System.Collections.Generic;
using System.Text;

namespace TALTechChallenge.Core.Common.Exceptions
{
    public class NotFoundException : BaseException
    {
        public NotFoundException(string errorCode) : base(errorCode, Constants.ValidatorMessages.NotFound)
        {
        }
    }
}
