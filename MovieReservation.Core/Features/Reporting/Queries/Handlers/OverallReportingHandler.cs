using MediatR;
using MovieReservation.Core.Bases;
using MovieReservation.Core.Features.Reporting.Queries.Models;
using MovieReservation.Core.Features.Reporting.Queries.Results;
using MovieReservation.Data.Results;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Core.Features.Reporting.Queries.Handlers
{
    public class OverallReportingHandler : ResponseHandler,
                                           IRequestHandler<OverallReportingQuery, Response<OverallReportingResponse>>,
                                           IRequestHandler<NewUsersStatsQuery, Response<int>>,
                                           IRequestHandler<ReservationStatsQuery, Response<ReservationStatsResponse>>

    {
        #region Fields
        private readonly IMovieService _movieService;
        private readonly ICategoryService _categoryService;
        private readonly IReservationService _reservationService;
        private readonly IShowtimeService _showtimeService;
        private readonly ITheaterService _theaterService;
        private readonly IAppUserService _appUserService;
        #endregion


        #region Constructors
        public OverallReportingHandler(
                                       IMovieService movieService,
                                       ICategoryService categoryService,
                                       IReservationService reservationService,
                                       IShowtimeService showtimeService,
                                       ITheaterService theaterService,
                                       IAppUserService appUserService)
        {
            _movieService = movieService;
            _categoryService = categoryService;
            _reservationService = reservationService;
            _showtimeService = showtimeService;
            _theaterService = theaterService;
            _appUserService = appUserService;
        }

        #endregion


        #region Functions
        public async Task<Response<OverallReportingResponse>> Handle(OverallReportingQuery request, CancellationToken cancellationToken)
        {


            var Overall = new OverallReportingResponse
            {
                MoviesNumber = await _movieService.GetMoviesCountAsync(),
                CategoriesNumber = await _categoryService.GetCategoriesCountAsync(),
                TheatersNumber = await _theaterService.GetTheatersCountAsync(),
                UsersNumber = await _appUserService.GetUsersCountAsync(null, null),
                ReservationsNumber = await _reservationService.GetReservationsCountAsync(),
                ShowtimesNumber = await _showtimeService.GetShowtimesCountAsync()
            };
            return Success(Overall);
        }

        public async Task<Response<int>> Handle(NewUsersStatsQuery request, CancellationToken cancellationToken)
        {
            var NewUsers = await _appUserService.GetUsersCountAsync(request.From, request.To);
            return Success(NewUsers);
        }

        public async Task<Response<ReservationStatsResponse>> Handle(ReservationStatsQuery request, CancellationToken cancellationToken)
        {
            var ReservationStats = await _reservationService.GetReservationStatsAsync(request.From, request.To);
            return Success(ReservationStats);
        }

        #endregion

    }
}
