using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Categories.Queries.Results;
namespace MovieReservation.Core.Features.Categories.Queries.Models
{
    public class GetCategoryListQuery : IRequest<Response<List<GetCategoryListResponse>>>
    {

    }
}
