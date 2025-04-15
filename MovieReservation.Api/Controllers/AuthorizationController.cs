using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Authorization.Commands.Models;
using MovieReservation.Core.Features.Authorization.Queries.Models;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{

    [ApiController]
    [Authorize(Roles = "Admin")]
    public class AuthorizationController : AppControllerBase
    {
        [HttpPost(Router.AuthorizationRouting.AddAdminRole)]
        public async Task<IActionResult> AddAdminRole(int userId)
        {
            var response = await Mediator.Send(new AddUserToAdminRoleCommand(userId));
            return NewResult(response);
        }

        [HttpPost(Router.AuthorizationRouting.RemoveAdminRole)]
        public async Task<IActionResult> RemoveAdminRole(int userId)
        {
            var response = await Mediator.Send(new RemoveUserFromAdminRoleCommand(userId));
            return NewResult(response);
        }

        [HttpGet(Router.AuthorizationRouting.AllAdmins)]
        public async Task<IActionResult> GetAllAdmins()
        {
            var response = await Mediator.Send(new GetAllAdminsQuery());
            return Ok(response);
        }



    }
}
