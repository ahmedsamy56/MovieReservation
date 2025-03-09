using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Theaters.Commands.Models
{
    public class DeleteTheaterCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteTheaterCommand(int id)
        {
            this.Id = id;
        }
    }
}
