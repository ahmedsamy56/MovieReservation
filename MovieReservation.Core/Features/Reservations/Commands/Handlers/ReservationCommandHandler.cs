using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Reservations.Commands.Models;
using MovieReservation.Core.Features.Reservations.Commands.Results;
using MovieReservation.Data.Entities;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Reservations.Commands.Handlers
{
    internal class ReservationCommandHandler : ResponseHandler,
                                          IRequestHandler<AddReservationCommand, Response<Ticket>>,
                                          IRequestHandler<DeleteReservationCommand, Response<string>>
    {
        #region Fields
        private readonly IReservationService _reservationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ReservationCommandHandler(IReservationService reservationService, IMapper mapper, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _reservationService = reservationService;
            _httpContextAccessor = httpContextAccessor;
        }
        #endregion

        #region Functions

        public async Task<Response<Ticket>> Handle(AddReservationCommand request, CancellationToken cancellationToken)
        {
            //Mapping 
            var ReservationMapping = _mapper.Map<Reservation>(request);

            var result = await _reservationService.AddReservationAsync(ReservationMapping);
            switch (result)
            {
                case "Unauthenticated":
                    return Unauthorized<Ticket>();
                case "AgeRestriction":
                    return BadRequest<Ticket>("This user is not allowed to view this movie.");
                case "ShowtimeHasPassed":
                    return BadRequest<Ticket>("This show has been shown in the past.");
            }

            var MyReservationId = int.Parse(result);
            var createdReservation = await _reservationService.GetReservationByIdWithIncludeAsync(MyReservationId);

            var resquestAccessor = _httpContextAccessor.HttpContext.Request;

            var ticket = new Ticket
            {
                UserName = createdReservation.AppUser.Name,
                MovieName = createdReservation.Showtime.Movie.Title,
                TheaterName = createdReservation.Showtime.Theater.Name,
                StartTime = createdReservation.Showtime.StartTime,
                ValidationLink = resquestAccessor.Scheme + "://" + resquestAccessor.Host + $"/Api/V1/Reservation/ValidateReservation?SecretCode={createdReservation.SecretCode}"
            };

            return Success(ticket);
        }

        public async Task<Response<string>> Handle(DeleteReservationCommand request, CancellationToken cancellationToken)
        {
            var result = await _reservationService.DeleteReservationAsync(request.Id);
            switch (result)
            {
                case "NotFound":
                    return NotFound<string>("Reservation NotFound");
                case "Unauthorized":
                    return Unauthorized<string>("You are not allowed to cancel this reservation.");
                case "ShowtimeHasPassed":
                    return BadRequest<string>("This show has been shown in the past.");
                case "Success":
                    return Deleted<string>();
                default:
                    return BadRequest<string>();
            }
        }




        #endregion

    }
}
