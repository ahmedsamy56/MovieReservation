using FluentValidation;
using MovieReservation.Core.Features.Showtimes.Commands.Models;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Showtimes.Commands.Validatiors
{
    public class AddShowtimeValidatior : AbstractValidator<AddShowtimeCommand>
    {
        #region Fields
        private readonly IMovieService _movieService;
        private readonly ITheaterService _theaterService;
        #endregion

        #region Constructors
        public AddShowtimeValidatior(IMovieService movieService, ITheaterService theaterService)
        {
            _movieService = movieService;
            _theaterService = theaterService;

            ApplyValidationsRules();
            ApplyCustomValidationsRules();
        }

        #endregion


        #region Functions
        public void ApplyValidationsRules()
        {
            RuleFor(x => x.Price)
                    .GreaterThan(0).WithMessage("Price must be greater than 0.");
            RuleFor(x => x.StartTime)
                   .GreaterThan(DateTime.Now).WithMessage("Start time must be in the future.");
        }

        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.MovieNumber)

                    .MustAsync(async (movieNumber, cancellation) => await _movieService.MovieExistAsync(movieNumber))
                    .WithMessage("Movie does not exist.");

            RuleFor(x => x.TheaterNumber)
                    .MustAsync(async (theaterNumber, cancellation) => await _theaterService.TheaterExistsAsync(theaterNumber))
                    .WithMessage("Theater does not exist.");

            RuleFor(x => new { x.TheaterNumber, x.StartTime, x.MovieNumber })
        .MustAsync(async (data, cancellation) =>
                             await _theaterService.IsTheaterAvailableAsync(data.TheaterNumber, data.StartTime, data.MovieNumber))
                             .WithMessage("Theater is not available during this time.");
        }

        #endregion
    }
}
