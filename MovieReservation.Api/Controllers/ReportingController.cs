using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Reporting.Queries.Models;
using MovieReservation.Data.Helpers;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    [Authorize(Roles = SD.AdminRole)]
    public class ReportingController : AppControllerBase
    {
        [HttpGet(Router.ReportingRouting.Overall)]
        public async Task<IActionResult> Overall()
        {
            var response = await Mediator.Send(new OverallReportingQuery());
            return NewResult(response);
        }

        [HttpGet(Router.ReportingRouting.NewUsersStats)]
        public async Task<IActionResult> NewUsers([FromQuery] NewUsersStatsQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

        [HttpGet(Router.ReportingRouting.ReservationStats)]
        public async Task<IActionResult> ReservationStats([FromQuery] ReservationStatsQuery query)
        {
            var response = await Mediator.Send(query);
            return NewResult(response);
        }

    }
}
