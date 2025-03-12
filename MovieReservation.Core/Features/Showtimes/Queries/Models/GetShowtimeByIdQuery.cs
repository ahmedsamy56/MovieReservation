using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Showtimes.Queries.Results;

namespace MovieReservation.Core.Features.Showtimes.Queries.Models
{
    public class GetShowtimeByIdQuery : IRequest<Response<GetShowtimeByIdResponse>>
    {
        public int Id { get; set; }
        public GetShowtimeByIdQuery(int id)
        {
            Id = id;
        }
    }
}
