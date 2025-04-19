using FluentValidation;
using MovieReservation.Core.Features.Reservations.Commands.Models;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Reservations.Commands.Validatiors
{
    public class AddReservationValidatior : AbstractValidator<AddReservationCommand>
    {
        #region Fields
        private readonly IReservationService _reservationService;
        private readonly IShowtimeService _showtimeService;

        #endregion

        #region Constructors
        public AddReservationValidatior(IReservationService reservationService, IShowtimeService showtimeService)
        {
            _reservationService = reservationService;
            _showtimeService = showtimeService;
            ApplyValidationRules();
            ApplyCustomValidationRules();

        }

        #endregion


        #region Functions
        public void ApplyValidationRules()
        {
            RuleFor(x => x.SeatNumber)
                .GreaterThan(0).WithMessage("Seat number must be greater than 0");

            RuleFor(x => x.ShowtimeId)
                .GreaterThan(0).WithMessage("Invalid showtime ID");
        }

        private void ApplyCustomValidationRules()
        {
            RuleFor(x => x.ShowtimeId)
                .MustAsync(async (showtimeId, cancellation) =>
                {
                    var showtime = await _showtimeService.GetShowtimeByIdWithIncludeAsync(showtimeId);
                    return showtime != null;
                })
                .WithMessage("Showtime does not exist")
                .DependentRules(() =>
                {
                    RuleFor(x => x)
                        .MustAsync(async (command, cancellation) =>
                        {
                            var showtime = await _showtimeService.GetShowtimeByIdWithIncludeAsync(command.ShowtimeId);
                            return command.SeatNumber <= showtime.Theater.totalSeats;
                        })
                        .WithMessage("Seat number exceeds the total number of seats for this showtime");

                    RuleFor(x => x)
                        .MustAsync(async (command, cancellation) =>
                        {
                            return !await _reservationService.IsSeatTakenAsync(command.ShowtimeId, command.SeatNumber);
                        })
                        .WithMessage("This seat is already taken for the selected showtime");
                });
        }


        #endregion
    }
}
