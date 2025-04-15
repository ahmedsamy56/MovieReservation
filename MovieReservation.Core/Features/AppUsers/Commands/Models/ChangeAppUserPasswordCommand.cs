using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.AppUsers.Commands.Models
{
    public class ChangeAppUserPasswordCommand : IRequest<Response<string>>
    {
        public string CurrentPassword { get; set; }
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
