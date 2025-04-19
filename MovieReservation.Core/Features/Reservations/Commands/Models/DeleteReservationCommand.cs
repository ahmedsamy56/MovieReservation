using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Reservations.Commands.Models
{
    public class DeleteReservationCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteReservationCommand(int id)
        {
            Id = id;
        }
    }
}
