using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Authentication.Queries.Models
{
    public class AuthorizeUserQuery : IRequest<Response<string>>
    {
        public string AccessToken { get; set; }
    }
}
