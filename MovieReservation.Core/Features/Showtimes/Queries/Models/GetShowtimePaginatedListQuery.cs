using MediatR;
using MovieReservation.Core.Features.Showtimes.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Data.Enums;

namespace MovieReservation.Core.Features.Showtimes.Queries.Models
{
    public class GetShowtimePaginatedListQuery : IRequest<PaginatedResult<GetShowtimePaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ShowtimeOrderingEnum orderingEnum { get; set; }
        public string? Search { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
