using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Theaters.Queries.Results;

namespace MovieReservation.Core.Features.Theaters.Queries.Models
{
    public class GetTheaterByIdQuery : IRequest<Response<GetTheaterByIdResponse>>
    {
        public int Id { get; set; }
        public GetTheaterByIdQuery(int id)
        {
            Id = id;
        }
    }
}
