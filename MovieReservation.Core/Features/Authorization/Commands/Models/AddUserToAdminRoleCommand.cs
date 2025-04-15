using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Authorization.Commands.Models
{
    public class AddUserToAdminRoleCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public AddUserToAdminRoleCommand(int id)
        {
            UserId = id;
        }
    }
}
