using FluentValidation;
using MovieReservation.Core.Features.Authentication.Commands.Models;

namespace MovieReservation.Core.Features.Authentication.Commands.Validators
{
    public class SignInValidator : AbstractValidator<SignInCommand>
    {
        #region Fields
        #endregion

        #region Constructors
        public SignInValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Email)
                 .NotEmpty().WithMessage("Email must not be empty")
                 .NotNull().WithMessage("Email must not be null")
                 .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password must not be empty")
                .NotNull().WithMessage("Password must not be null");
        }

        public void ApplyCustomValidationsRules()
        {
        }

        #endregion
    }
}
