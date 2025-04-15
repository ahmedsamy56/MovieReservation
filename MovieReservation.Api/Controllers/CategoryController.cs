using Microsoft.AspNetCore.Mvc;
using MovieReservation.Api.Base;
using MovieReservation.Core.Features.Categories.Commands.Models;
using MovieReservation.Core.Features.Categories.Queries.Models;
using MovieReservation.Data.Routing;

namespace MovieReservation.Api.Controllers
{
    public class CategoryController : AppControllerBase
    {


        [HttpPost(Router.CategoryRouting.Create)]
        public async Task<IActionResult> Create([FromBody] AddCategoryCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpGet(Router.CategoryRouting.GetByID)]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await Mediator.Send(new GetCategoryByIdQuery(id));
            return NewResult(response);
        }
        [HttpGet(Router.CategoryRouting.List)]
        public async Task<IActionResult> GetCategoryList()
        {
            var response = await Mediator.Send(new GetCategoryListQuery());
            return Ok(response);

        }

        [HttpPut(Router.CategoryRouting.Edit)]
        public async Task<IActionResult> Update([FromBody] EditCategoryCommand request)
        {
            var response = await Mediator.Send(request);
            return NewResult(response);
        }

        [HttpDelete(Router.CategoryRouting.Delete)]

        public async Task<IActionResult> Delete(int id)
        {
            var response = await Mediator.Send(new DeleteCategoryCommand(id));
            return NewResult(response);
        }
    }
}
