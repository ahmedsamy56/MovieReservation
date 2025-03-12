using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Showtimes.Commands.Models
{
    public class DeleteShowtimeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteShowtimeCommand(int id)
        {
            this.Id = id;
        }

    }
}
