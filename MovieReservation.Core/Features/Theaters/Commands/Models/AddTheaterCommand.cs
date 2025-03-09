using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Theaters.Commands.Models
{
    public class AddTheaterCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public int totalSeats { get; set; }
    }
}
