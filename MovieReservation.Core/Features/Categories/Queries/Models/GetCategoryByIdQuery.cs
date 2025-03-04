
using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Categories.Queries.Results;

namespace MovieReservation.Core.Features.Categories.Queries.Models
{
    public class GetCategoryByIdQuery : IRequest<Response<GetCategoryByIdResponse>>
    {
        public int id { get; set; }

        public GetCategoryByIdQuery(int id)
        {
            this.id = id;
        }

    }
}
