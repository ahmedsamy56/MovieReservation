using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Emails.Commands.Models;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    [ApiController]
    public class EmailsController : AppControllerBase
    {
        [HttpPost(Router.EmailsRoute.SendEmail)]
        public async Task<IActionResult> SendEmail([FromQuery] SendEmailCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }
    }
}
