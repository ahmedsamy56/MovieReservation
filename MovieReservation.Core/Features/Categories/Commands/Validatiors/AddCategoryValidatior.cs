using FluentValidation;
using MovieReservation.Core.Features.Categories.Commands.Models;

namespace MovieReservation.Core.Features.Categories.Commands.Validatiors
{
    public class AddCategoryValidatior : AbstractValidator<AddCategoryCommand>
    {
        #region Fields

        #endregion

        #region Constructors
        public AddCategoryValidatior()
        {
            ApplyValidationsRules();
        }

        #endregion


        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be Null")
                .MaximumLength(50);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be Null");
        }

        public void ApplyCustomValidationsRules()
        {

        }

        #endregion
    }
}
