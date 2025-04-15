using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Authorization.Queries.Results;

namespace MovieReservation.Core.Features.Authorization.Queries.Models
{
    public class GetAllAdminsQuery : IRequest<Response<List<GetAllAdminsResponse>>>
    {

    }
}
