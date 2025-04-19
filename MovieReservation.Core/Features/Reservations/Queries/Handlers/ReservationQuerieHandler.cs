using MediatR;
using Microsoft.AspNetCore.Http;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Reservations.Queries.Models;
using MovieReservation.Core.Features.Reservations.Queries.Results;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Reservations.Queries.Handlers
{
    public class ReservationQuerieHandler : ResponseHandler,
                                          IRequestHandler<ValidateReservationQuerie, Response<string>>,
                                          IRequestHandler<GetMyTicketQuerie, Response<GetMyTicketResponse>>
    {
        #region Fields
        private readonly IReservationService _reservationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUserService _currentUserService;
        #endregion

        #region Constructors
        public ReservationQuerieHandler(IReservationService reservationService, IHttpContextAccessor httpContextAccessor, ICurrentUserService currentUserService)
        {
            _reservationService = reservationService;
            _httpContextAccessor = httpContextAccessor;
            _currentUserService = currentUserService;
        }

        #endregion

        #region Functions

        public async Task<Response<string>> Handle(ValidateReservationQuerie request, CancellationToken cancellationToken)
        {
            var result = await _reservationService.ValidateReservationAsync(request.SecretCode);
            if (result == "Fake") return BadRequest<string>("Fake Reservation");
            else if (result == "valid") return Success<string>("vaild Reservation");
            else return BadRequest<string>();
        }

        public async Task<Response<GetMyTicketResponse>> Handle(GetMyTicketQuerie request, CancellationToken cancellationToken)
        {
            var reservation = await _reservationService.GetReservationByIdWithIncludeAsync(request.Id);
            if (reservation == null) return NotFound<GetMyTicketResponse>();

            int userId = _currentUserService.GetUserId();
            if (userId != reservation.AppUserId) return Unauthorized<GetMyTicketResponse>("You are not allowed to show that ticket.");

            var resquestAccessor = _httpContextAccessor.HttpContext.Request;
            var ticket = new GetMyTicketResponse
            {
                UserName = reservation.AppUser.Name,
                MovieName = reservation.Showtime.Movie.Title,
                TheaterName = reservation.Showtime.Theater.Name,
                StartTime = reservation.Showtime.StartTime,
                ValidationLink = resquestAccessor.Scheme + "://" + resquestAccessor.Host + $"/Api/V1/Reservation/ValidateReservation?SecretCode={reservation.SecretCode}"
            };

            return Success(ticket);
        }


        #endregion
    }
}
