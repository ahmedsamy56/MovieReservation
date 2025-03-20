using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Data.Helpers;

namespace MovieReservation.Core.Features.Authentication.Commands.Models
{
    public class RefreshTokenCommand : IRequest<Response<JwtResult>>
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
