using FluentValidation;
using MovieReservation.Core.Features.AppUsers.Commands.Models;

namespace MovieReservation.Core.Features.AppUsers.Commands.Validatiors
{
    public class EditAppUserValidator : AbstractValidator<EditAppUserCommand>
    {
        #region Fields

        #endregion

        #region Constructors
        public EditAppUserValidator()
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


        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
