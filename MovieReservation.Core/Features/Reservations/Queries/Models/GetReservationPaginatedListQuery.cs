using MediatR;
using MovieReservation.Core.Features.Reservations.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Data.Enums;

namespace MovieReservation.Core.Features.Reservations.Queries.Models
{
    public class GetReservationPaginatedListQuery : IRequest<PaginatedResult<GetReservationPaginatedListResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public ReservayionOrderingEnum orderingEnum { get; set; }
        public string? Search { get; set; }
    }
}
