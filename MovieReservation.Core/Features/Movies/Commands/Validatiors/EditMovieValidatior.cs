using FluentValidation;
using MovieReservation.Core.Features.Movies.Commands.Models;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Movies.Commands.Validatiors
{
    public class EditMovieValidatior : AbstractValidator<EditMovieCommand>
    {
        #region Fields
        private readonly ICategoryService _categoryService;
        #endregion

        #region Constructors
        public EditMovieValidatior(ICategoryService categoryService)
        {
            _categoryService = categoryService;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Name must not be empty")
                .NotNull().WithMessage("Name must not be Null")
                .MaximumLength(50);
            RuleFor(x => x.Description)
                .NotEmpty().WithMessage("Description must not be empty")
                .NotNull().WithMessage("Description must not be Null");

            RuleFor(x => x.DurationInMinutes)
                 .GreaterThan(0)
                 .WithMessage("Duration must be greater than 0 minutes.");

            RuleFor(x => x.releaseDate)
                  .LessThan(DateOnly.FromDateTime(DateTime.Today))
                  .WithMessage("Release date must be in the past.");


        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.CategoryNumber)
            .MustAsync(async (categoryNumber, cancellation) => await _categoryService.CategoryExistAsync(categoryNumber))
            .WithMessage("Category does not exist.");

        }

        #endregion
    }
}
