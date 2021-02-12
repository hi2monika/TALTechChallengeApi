using FluentValidation;

namespace TALTechChallenge.Core.Command
{
    //TODO : Show case how to handle command ,Demo purpose only
    public class CreateCommandValidator : AbstractValidator<CreateCommand>
    {
        public CreateCommandValidator()
        {
            CascadeMode = CascadeMode.StopOnFirstFailure;

           // Validation            

        }
    }
}
