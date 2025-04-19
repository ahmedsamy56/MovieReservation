using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Reservations.Commands.Results;

namespace MovieReservation.Core.Features.Reservations.Commands.Models
{
    public class AddReservationCommand : IRequest<Response<Ticket>>
    {
        public int ShowtimeId { get; set; }
        public int SeatNumber { get; set; }
    }
}
