using FluentValidation;
using MovieReservation.Core.Features.AppUsers.Commands.Models;

namespace MovieReservation.Core.Features.AppUsers.Commands.Validatiors
{
    public class ChangeAppUserPasswordValidator : AbstractValidator<ChangeAppUserPasswordCommand>
    {
        #region Fields

        #endregion

        #region Constructors
        public ChangeAppUserPasswordValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.CurrentPassword)
                .NotEmpty().WithMessage("Current password must not be empty")
                .NotNull().WithMessage("Current password must not be null");

            RuleFor(x => x.NewPassword)
                .NotEmpty().WithMessage("Password must not be empty")
                .NotNull().WithMessage("Password must not be null")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"\d").WithMessage("Password must contain at least one number")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password must not be empty")
                .Equal(x => x.NewPassword).WithMessage("Passwords do not match");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
