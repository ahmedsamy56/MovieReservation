using MediatR;
using MovieReservation.Core.Features.Theaters.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Data.Enums;

namespace MovieReservation.Core.Features.Theaters.Queries.Models
{
    public class GetTheaterPaginatedListQuery : IRequest<PaginatedResult<GetTheaterPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public TheaterOrderingEnum orderingEnum { get; set; }
        public string? Search { get; set; }
    }
}
