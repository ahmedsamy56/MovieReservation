using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Showtimes.Commands.Models;
using MovieReservation.Core.Features.Showtimes.Queries.Models;
using MovieReservation.Data.Helpers;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    public class ShowtimeController : AppControllerBase
    {
        [Authorize(Roles = SD.AdminRole)]
        [HttpPost(Router.ShowtimeRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddShowtimeCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [Authorize(Roles = SD.AdminRole)]
        [HttpPut(Router.ShowtimeRouting.Edit)]
        public async Task<IActionResult> UpdateShowtime([FromBody] EditShowtimeCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpGet(Router.ShowtimeRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetShowtimePaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.ShowtimeRouting.GetByID)]
        public async Task<IActionResult> GetShowtimeById(int id)
        {
            var response = await Mediator.Send(new GetShowtimeByIdQuery(id));
            return NewResult(response);
        }

        [Authorize(Roles = SD.AdminRole)]
        [HttpDelete(Router.ShowtimeRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteShowtimeCommand(id));
            return NewResult(response);
        }
    }
}