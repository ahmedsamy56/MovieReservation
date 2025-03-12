using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Showtimes.Commands.Models
{
    public class EditShowtimeCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieNumber { get; set; }
        public int TheaterNumber { get; set; }
    }
}
