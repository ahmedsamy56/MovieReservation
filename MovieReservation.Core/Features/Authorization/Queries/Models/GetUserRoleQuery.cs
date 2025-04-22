using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Data.Results;

namespace MovieReservation.Core.Features.Authorization.Queries.Models
{
    public class GetUserRoleQuery : IRequest<Response<GetUserRoleRespons>>
    {
        public int userId { get; set; }
        public GetUserRoleQuery(int Id)
        {
            userId = Id;
        }
    }
}
