using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.AppUsers.Commands.Models
{
    public class DeleteAppUserCommand : IRequest<Response<string>>
    {

    }
}
