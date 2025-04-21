using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Movies.Commands.Models;
using MovieReservation.Core.Features.Movies.Queries.Models;
using MovieReservation.Data.Helpers;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    public class MovieController : AppControllerBase
    {
        [Authorize(Roles = SD.AdminRole)]
        [HttpPost(Router.MovieRouting.Create)]
        public async Task<IActionResult> Create([FromForm] AddMovieCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [HttpGet(Router.MovieRouting.GetByID)]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var response = await Mediator.Send(new GetMovieByIdQuery(id));
            return NewResult(response);
        }

        [HttpGet(Router.MovieRouting.Paginated)]
        public async Task<IActionResult> Paginated([FromQuery] GetMoviesPaginatedListQuery query)
        {
            var response = await Mediator.Send(query);
            return Ok(response);
        }

        [Authorize(Roles = SD.AdminRole)]
        [HttpPut(Router.MovieRouting.Edit)]
        public async Task<IActionResult> UpdateMovie([FromForm] EditMovieCommand command)
        {
            var response = await Mediator.Send(command);
            return NewResult(response);
        }

        [Authorize(Roles = SD.AdminRole)]
        [HttpDelete(Router.MovieRouting.Delete)]
        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteMovieCommand(id));
            return NewResult(response);
        }

    }
}
