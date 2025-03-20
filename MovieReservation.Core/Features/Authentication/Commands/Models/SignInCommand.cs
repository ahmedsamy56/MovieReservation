using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Data.Helpers;

namespace MovieReservation.Core.Features.Authentication.Commands.Models
{
    public class SignInCommand : IRequest<Response<JwtResult>>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
