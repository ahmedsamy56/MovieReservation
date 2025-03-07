using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Movies.Commands.Models
{
    public class DeleteMovieCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteMovieCommand(int id)
        {
            Id = id;
        }
    }
}
