using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.AppUsers.Commands.Models;
using MovieReservation.Core.Features.AppUsers.Queries.Models;
using MovieReservation.Data.Helpers;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    [Authorize]
    public class AppUserController : AppControllerBase
    {
        [AllowAnonymous]
        [HttpPost(Router.AppUserRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddAppUserCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [Authorize(Roles = SD.AdminRole)]
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

        [HttpPut(Router.AppUserRouting.Edit)]
        public async Task<IActionResult> Edit([FromBody] EditAppUserCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpDelete(Router.AppUserRouting.Delete)]
        public async Task<IActionResult> Delete()
        {
            return NewResult(await Mediator.Send(new DeleteAppUserCommand()));
        }

        [HttpPut(Router.AppUserRouting.ChangePassword)]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeAppUserPasswordCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
