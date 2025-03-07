using MediatR;
using MovieReservation.Core.Features.Movies.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Data.Enums;

namespace MovieReservation.Core.Features.Movies.Queries.Models
{
    public class GetMoviesPaginatedListQuery : IRequest<PaginatedResult<GetMoviesPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public MovieOrderingEnum orderingEnum { get; set; }
        public string? Search { get; set; }
    }
}
