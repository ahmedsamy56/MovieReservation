using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Reporting.Queries.Results;

namespace MovieReservation.Core.Features.Reporting.Queries.Models
{
    public class OverallReportingQuery : IRequest<Response<OverallReportingResponse>>
    {

    }
}
