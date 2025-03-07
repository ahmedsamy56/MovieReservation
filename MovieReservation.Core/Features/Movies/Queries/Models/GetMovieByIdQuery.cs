using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Movies.Queries.Results;

namespace MovieReservation.Core.Features.Movies.Queries.Models
{
    public class GetMovieByIdQuery : IRequest<Response<GetMovieByIdResponse>>
    {
        public int Id { get; set; }
        public GetMovieByIdQuery(int id)
        {
            Id = id;
        }
    }
}
