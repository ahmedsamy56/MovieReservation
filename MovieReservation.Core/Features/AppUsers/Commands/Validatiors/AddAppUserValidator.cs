using FluentValidation;
using MovieReservation.Core.Features.AppUsers.Commands.Models;

namespace MovieReservation.Core.Features.AppUsers.Commands.Validatiors
{
    public class AddAppUserValidator : AbstractValidator<AddAppUserCommand>
    {
        #region Fields

        #endregion

        #region Constructors
        public AddAppUserValidator()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
             .NotEmpty().WithMessage("Name must not be empty")
             .NotNull().WithMessage("Name must not be null")
             .MaximumLength(50).WithMessage("Name must not exceed 50 characters");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email must not be empty")
                .NotNull().WithMessage("Email must not be null")
                .EmailAddress().WithMessage("Invalid email format");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty().WithMessage("Phone number must not be empty")
                .NotNull().WithMessage("Phone number must not be null")
                .Matches(@"^\+?\d{10,15}$").WithMessage("Invalid phone number format");

            RuleFor(x => x.Birthday)
                .NotEmpty().WithMessage("Birthday must not be empty")
                .LessThan(DateOnly.FromDateTime(DateTime.UtcNow)).WithMessage("Birthday must be in the past");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Password must not be empty")
                .NotNull().WithMessage("Password must not be null")
                .MinimumLength(8).WithMessage("Password must be at least 8 characters long")
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"\d").WithMessage("Password must contain at least one number")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character");

            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage("Confirm Password must not be empty")
                .Equal(x => x.Password).WithMessage("Passwords do not match");

        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
