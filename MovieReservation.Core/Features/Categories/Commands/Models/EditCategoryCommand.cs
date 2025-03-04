using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Categories.Commands.Models
{
    public class EditCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
