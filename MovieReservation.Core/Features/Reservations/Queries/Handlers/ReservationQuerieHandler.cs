using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Reservations.Queries.Models;
using MovieReservation.Core.Features.Reservations.Queries.Results;
using MovieReservation.Core.Wrappers;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Reservations.Queries.Handlers
{
    public class ReservationQuerieHandler : ResponseHandler,
                                          IRequestHandler<ValidateReservationQuerie, Response<string>>,
                                          IRequestHandler<GetMyTicketQuerie, Response<GetMyTicketResponse>>,
                                          IRequestHandler<GetReservationPaginatedListQuery, PaginatedResult<GetReservationPaginatedListResponse>>

    {
        #region Fields
        private readonly IReservationService _reservationService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ICurrentUserService _currentUserService;
        private readonly IMapper _mapper;
        #endregion

        #region Constructors
        public ReservationQuerieHandler(IReservationService reservationService, IHttpContextAccessor httpContextAccessor, ICurrentUserService currentUserService, IMapper mapper)
        {
            _reservationService = reservationService;
            _httpContextAccessor = httpContextAccessor;
            _currentUserService = currentUserService;
            _mapper = mapper;
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

        public async Task<PaginatedResult<GetReservationPaginatedListResponse>> Handle(GetReservationPaginatedListQuery request, CancellationToken cancellationToken)
        {
            var FilterQuery = _reservationService.FilterReservationPaginatedQuerable(request.orderingEnum, request.Search);
            var PaginatedListMapping = await _mapper.ProjectTo<GetReservationPaginatedListResponse>(FilterQuery).ToPaginatedListAsync(request.PageNumber, request.PageSize);
            PaginatedListMapping.Meta = new { Count = PaginatedListMapping.Data.Count() };
            return PaginatedListMapping;
        }




        #endregion
    }
}
