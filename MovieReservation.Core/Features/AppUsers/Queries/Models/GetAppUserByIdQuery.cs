using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.AppUsers.Queries.Results;

namespace MovieReservation.Core.Features.AppUsers.Queries.Models
{
    public class GetAppUserByIdQuery : IRequest<Response<GetAppUserByIdResponse>>
    {
        public int Id { get; set; }
        public GetAppUserByIdQuery(int id)
        {
            Id = id;
        }
    }
}
