using FluentValidation;
using MovieReservation.Core.Features.Authentication.Queries.Models;

namespace MovieReservation.Core.Features.Authentication.Queries.Validatiors
{
    public class ConfirmEmailValidator : AbstractValidator<ConfirmEmailQuery>
    {
        #region Fields

        #endregion

        #region Constructors
        public ConfirmEmailValidator()
        {

            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }
        #endregion

        #region Actions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("UserId must not be empty")
                .NotNull().WithMessage("UserId is required");

            RuleFor(x => x.Code)
                .NotEmpty().WithMessage("Code must not be empty")
                .NotNull().WithMessage("Code is required");
        }

        public void ApplyCustomValidationsRules()
        {
        }

        #endregion

    }
}
