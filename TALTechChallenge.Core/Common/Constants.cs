namespace TALTechChallenge.Core.Common
{
    public class Constants
    {
        public static class ErrorCodes
        {
            public const string RatingNotFound = "RATE02";
            public const string OccupationNotFound = "OCPM202";
            public const string InValidObject = "203";
        }
        public static class ValidatorMessages
        {
            internal const string InvalidObjectInRequest = "Invalid object provided in the request.";
            internal const string EmptyBodyRequest = "Empty object provided in the request.";
            internal const string NotFound = "Not Found";
        }
    }
}
