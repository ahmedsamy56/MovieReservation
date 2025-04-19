using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class ReservationService : IReservationService
    {


        #region Fields
        private readonly IReservationRepository _reservationRepository;
        private readonly ICurrentUserService _currentUserService;
        private readonly UserManager<AppUser> _userManager;
        private readonly IShowtimeService _showtimeService;
        #endregion


        #region Constructors
        public ReservationService(IReservationRepository reservationRepository, ICurrentUserService currentUserService,
                                   UserManager<AppUser> userManager, IShowtimeService showtimeService)
        {
            _reservationRepository = reservationRepository;
            _currentUserService = currentUserService;
            _userManager = userManager;
            _showtimeService = showtimeService;
        }

        #endregion


        #region Functions

        public async Task<bool> IsSeatTakenAsync(int showtimeId, int seatNumber)
        {
            return await _reservationRepository.GetTableNoTracking()
                 .AnyAsync(r => r.ShowtimeId == showtimeId && r.SeatNumber == seatNumber);
        }


        public async Task<string> AddReservationAsync(Reservation reservation)
        {
            var userId = _currentUserService.GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null) return "Unauthenticated";
            else reservation.AppUserId = userId;

            var showtime = await _showtimeService.GetShowtimeByIdWithIncludeAsync(reservation.ShowtimeId);
            if (showtime.Movie.SuitableAge > GetAge(user)) return "AgeRestriction";

            if (showtime.StartTime < DateTime.Now) return "ShowtimeHasPassed";


            var NewReservation = await _reservationRepository.AddAsync(reservation);
            var ReservationId = NewReservation.Id;
            return ReservationId.ToString();
        }

        private static int GetAge(AppUser user)
        {
            var today = DateOnly.FromDateTime(DateTime.Today);
            int age = today.Year - user.Birthday.Year;

            if (today < user.Birthday.AddYears(age))
            {
                age--;
            }

            return age;
        }

        public async Task<Reservation> GetReservationByIdWithIncludeAsync(int id)
        {
            var reservation = await _reservationRepository.GetTableNoTracking().Where(r => r.Id == id)
                .Include(r => r.AppUser)
                .Include(r => r.Showtime)
                    .ThenInclude(s => s.Movie)
                .Include(r => r.Showtime)
                    .ThenInclude(s => s.Theater)
                .FirstOrDefaultAsync();

            return reservation;
        }

        public async Task<string> DeleteReservationAsync(int reservationId)
        {
            var reservation = await _reservationRepository.GetTableNoTracking().Where(x => x.Id == reservationId).Include(x => x.Showtime).FirstOrDefaultAsync();
            if (reservation == null) return "NotFound";

            var useId = _currentUserService.GetUserId();
            if (reservation.AppUserId != useId) return "Unauthorized";
            if (reservation.Showtime.StartTime <= DateTime.Now) return "ShowtimeHasPassed";

            await _reservationRepository.DeleteAsync(reservation);
            return "Success";
        }

        public async Task<string> ValidateReservationAsync(string code)
        {
            var reservation = await _reservationRepository.GetTableNoTracking().Where(x => x.SecretCode == code).FirstOrDefaultAsync();

            if (reservation == null) return "Fake";
            return "valid";
        }



        #endregion
    }
}
