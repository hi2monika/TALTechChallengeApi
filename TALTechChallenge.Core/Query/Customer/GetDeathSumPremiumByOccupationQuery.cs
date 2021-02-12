using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using static TALTechChallenge.Core.Common.Constants;

namespace TALTechChallenge.Core.Query.Customer
{
    public class GetDeathSumPremiumByOccupationQuery: IRequest<double>
    {
        public string Age { get; set; }
        public string DeathSumInsured { get; set; }
        public string Occupation { get; set; }

        public GetDeathSumPremiumByOccupationQuery(string age, string deathSumInsured, string occupation)
        {
            Age = age;
            DeathSumInsured = deathSumInsured;
            Occupation = occupation;
        }

    }
    public class GetDeathSumPremiumByOccupationQueryValidator : AbstractValidator<GetDeathSumPremiumByOccupationQuery>
    {
        public GetDeathSumPremiumByOccupationQueryValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

            bool StringToInt(string value) => int.TryParse(value, out int val);
            bool StringToDouble(string value) => double.TryParse(value, out double val);

            //TODO Add Validation             
            RuleFor(GetPremiumBy => GetPremiumBy.Age)
              .NotEmpty()
              .WithErrorCode(ErrorCodes.InValidObject)
              .WithMessage(ValidatorMessages.InvalidObjectInRequest)
              .NotNull()
              .WithErrorCode(ErrorCodes.InValidObject)
              .WithMessage(ValidatorMessages.InvalidObjectInRequest);

            RuleFor(GetPremiumBy => GetPremiumBy.Age)
             .Must(StringToInt)
             .WithErrorCode(ErrorCodes.InValidObject)
             .WithMessage(ValidatorMessages.InvalidObjectInRequest)
             .NotNull()
             .WithErrorCode(ErrorCodes.InValidObject)
             .WithMessage(ValidatorMessages.InvalidObjectInRequest);
            

            RuleFor(GetPremiumBy => GetPremiumBy.DeathSumInsured)
             .NotEmpty()
             .WithErrorCode(ErrorCodes.InValidObject)
             .WithMessage(ValidatorMessages.InvalidObjectInRequest)
             .NotNull()
             .WithErrorCode(ErrorCodes.InValidObject)
             .WithMessage(ValidatorMessages.InvalidObjectInRequest);

            RuleFor(GetPremiumBy => GetPremiumBy.DeathSumInsured)
             .Must(StringToDouble)
             .WithErrorCode(ErrorCodes.InValidObject)
             .WithMessage(ValidatorMessages.InvalidObjectInRequest)
             .NotNull()
             .WithErrorCode(ErrorCodes.InValidObject)
             .WithMessage(ValidatorMessages.InvalidObjectInRequest);

            // TODO .Can be tested for only Valid Occupation
            RuleFor(GetPremiumBy => GetPremiumBy.Occupation)
            .NotEmpty()
            .WithErrorCode(ErrorCodes.InValidObject)
            .WithMessage(ValidatorMessages.InvalidObjectInRequest)
            .NotNull()
            .WithErrorCode(ErrorCodes.InValidObject)
            .WithMessage(ValidatorMessages.InvalidObjectInRequest);
        }
    }

}
