using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Reservations.Commands.Models;
using MovieReservation.Core.Features.Reservations.Queries.Models;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    [Authorize]
    public class ReservationController : AppControllerBase
    {
        [HttpPost(Router.ReservationRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddReservationCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }


        [HttpDelete(Router.ReservationRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteReservationCommand(id));
            return NewResult(response);
        }

        [AllowAnonymous]
        [HttpGet(Router.ReservationRouting.ValidateReservation)]
        public async Task<IActionResult> ValidateReservation(string SecretCode)
        {
            var response = await Mediator.Send(new ValidateReservationQuerie(SecretCode));
            return NewResult(response);
        }


        [HttpGet(Router.ReservationRouting.GetMyTicket)]
        public async Task<IActionResult> ValidateReservation(int id)
        {
            var response = await Mediator.Send(new GetMyTicketQuerie(id));
            return NewResult(response);
        }
    }
}
