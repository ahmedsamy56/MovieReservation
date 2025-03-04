using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Categories.Commands.Models
{
    public class AddCategoryCommand : IRequest<Response<string>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
