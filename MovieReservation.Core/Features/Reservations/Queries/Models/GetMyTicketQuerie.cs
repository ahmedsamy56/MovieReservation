using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Reservations.Queries.Results;

namespace MovieReservation.Core.Features.Reservations.Queries.Models
{
    public class GetMyTicketQuerie : IRequest<Response<GetMyTicketResponse>>
    {
        public int Id { get; set; }
        public GetMyTicketQuerie(int id)
        {
            Id = id;
        }
    }
}
