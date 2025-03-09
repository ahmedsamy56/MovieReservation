using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Theaters.Commands.Models
{
    public class EditTheaterCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int totalSeats { get; set; }
    }
}
