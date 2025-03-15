using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.AppUsers.Commands.Models;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    public class AppUserController : AppControllerBase
    {
        [HttpPost(Router.AppUser.Create)]
        public async Task<IActionResult> Create([FromBody] AddAppUserCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }
    }
}
