using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Data.Results;

namespace MovieReservation.Core.Features.Reporting.Queries.Models
{
    public class ReservationStatsQuery : IRequest<Response<ReservationStatsResponse>>
    {
        public DateTime? From { get; set; }
        public DateTime? To { get; set; }
    }
}
