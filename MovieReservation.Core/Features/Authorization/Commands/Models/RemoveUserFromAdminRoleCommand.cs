using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Authorization.Commands.Models
{
    public class RemoveUserFromAdminRoleCommand : IRequest<Response<string>>
    {
        public int UserId { get; set; }
        public RemoveUserFromAdminRoleCommand(int id)
        {
            UserId = id;
        }
    }
}
