using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.AppUsers.Commands.Models;
using MovieReservation.Core.Features.AppUsers.Queries.Models;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    public class AppUserController : AppControllerBase
    {
        [HttpPost(Router.AppUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddAppUserCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpGet(Router.AppUserRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetAppUserPaginationQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [HttpGet(Router.AppUserRouting.GetByID)]
        public async Task<IActionResult> GetAppUserById(int id)
        {
            var response = await Mediator.Send(new GetAppUserByIdQuery(id));
            return NewResult(response);
        }
    }
}
