using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Theaters.Commands.Models;
using MovieReservation.Core.Features.Theaters.Queries.Models;
using MovieReservation.Data.Helpers;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    public class TheaterController : AppControllerBase
    {
        [Authorize(Roles = SD.AdminRole)]
        [HttpPost(Router.TheaterRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddTheaterCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [Authorize(Roles = SD.AdminRole)]
        [HttpPut(Router.TheaterRouting.Edit)]
        public async Task<IActionResult> UpdateTheater([FromBody] EditTheaterCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpGet(Router.TheaterRouting.GetByID)]
        public async Task<IActionResult> GetTheaterById(int id)
        {
            var response = await Mediator.Send(new GetTheaterByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet(Router.TheaterRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetTheaterPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [Authorize(Roles = SD.AdminRole)]
        [HttpDelete(Router.TheaterRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteTheaterCommand(id));
            return NewResult(response);
        }
    }
}
