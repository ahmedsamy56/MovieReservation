using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Categories.Commands.Models
{
    public class DeleteCategoryCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteCategoryCommand(int id)
        {
            this.Id = id;
        }
    }
}
