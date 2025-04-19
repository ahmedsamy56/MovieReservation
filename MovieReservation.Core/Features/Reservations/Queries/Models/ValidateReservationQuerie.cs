using MediatR;
using MovieReservation.Core.Bases;

namespace MovieReservation.Core.Features.Reservations.Queries.Models
{
    public class ValidateReservationQuerie : IRequest<Response<string>>
    {
        public string SecretCode { get; set; }
        public ValidateReservationQuerie(string secretCode)
        {
            SecretCode = secretCode;
        }
    }
}
