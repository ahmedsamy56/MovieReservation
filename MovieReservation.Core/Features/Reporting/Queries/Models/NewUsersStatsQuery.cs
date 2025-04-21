using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Reporting.Queries.Models
{
    public record NewUsersStatsQuery : IRequest<Response<int>>
    {
        public DateTime? From { get; init; }
        public DateTime? To { get; init; }
    }
}
