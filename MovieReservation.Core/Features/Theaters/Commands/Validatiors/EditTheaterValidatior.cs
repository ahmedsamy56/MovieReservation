using FluentValidation;
using MovieReservation.Core.Features.Theaters.Commands.Models;

namespace MovieReservation.Core.Features.Theaters.Commands.Validatiors
{
    public class EditTheaterValidatior : AbstractValidator<EditTheaterCommand>
    {
        #region Fields

        #endregion

        #region Constructors
        public EditTheaterValidatior()
        {
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Theater name is required.")
            .MaximumLength(100).WithMessage("Theater name cannot exceed 100 characters.");

            RuleFor(x => x.totalSeats)
                .GreaterThan(0).WithMessage("Total seats must be greater than zero.")
                .LessThanOrEqualTo(1000).WithMessage("Total seats cannot exceed 1000.");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
