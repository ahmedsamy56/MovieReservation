using MediatR;
using MovieReservation.Core.Features.AppUsers.Queries.Results;
using MovieReservation.Core.Wrappers;

namespace MovieReservation.Core.Features.AppUsers.Queries.Models
{
    public class GetAppUserPaginationQuery : IRequest<PaginatedResult<GetAppUserPaginationReponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
    }
}
