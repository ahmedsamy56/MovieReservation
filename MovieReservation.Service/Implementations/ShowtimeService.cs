using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Data.Enums;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class ShowtimeService : IShowtimeService
    {
        #region Fields
        private readonly IShowtimeRepository _showtimeRepository;
        #endregion

        #region Constructors
        public ShowtimeService(IShowtimeRepository showtimeRepository)
        {
            _showtimeRepository = showtimeRepository;
        }
        #endregion


        #region Functions
        public async Task<string> AddShowtimeAsync(Showtime showtime)
        {
            await _showtimeRepository.AddAsync(showtime);
            return "Success";
        }

        public async Task<string> EditShowtimeAsync(Showtime showtime)
        {
            var existingShowtime = await _showtimeRepository.GetByIdAsync(showtime.Id);
            if (existingShowtime.StartTime < DateTime.UtcNow)
                return "PastShowtime";

            await _showtimeRepository.UpdateAsync(showtime);
            return "Success";
        }

        public async Task<Showtime> GetShowtimeByIdAsync(int id)
        {
            var showtime = await _showtimeRepository.GetByIdAsync(id);
            return showtime;
        }

        public IQueryable<Showtime> FilterShowtimePaginatedQuerable(ShowtimeOrderingEnum orderingEnum,
                                                                        string search,
                                                                        DateTime? startDate,
                                                                        DateTime? endDate)
        {
            var querable = _showtimeRepository.GetTableNoTracking()
                .Include(x => x.Movie)
                .Include(x => x.Theater)
                .AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                querable = querable.Where(x => x.Movie.Title.Contains(search) || x.Theater.Name.Contains(search));
            }


            if (startDate.HasValue)
                querable = querable.Where(x => x.StartTime >= startDate.Value);

            if (endDate.HasValue)
                querable = querable.Where(x => x.StartTime <= endDate.Value);


            querable = orderingEnum switch
            {
                ShowtimeOrderingEnum.Price => querable.OrderBy(x => x.Price),
                ShowtimeOrderingEnum.MovieNumber => querable.OrderBy(x => x.MovieId),
                ShowtimeOrderingEnum.TheaterNumber => querable.OrderBy(x => x.TheaterId),
                ShowtimeOrderingEnum.StartTime => querable.OrderBy(x => x.StartTime),
                _ => querable.OrderBy(x => x.Id),
            };

            return querable;
        }

        public async Task<Showtime> GetShowtimeByIdWithIncludeAsync(int id)
        {
            var showtime = await _showtimeRepository.GetTableNoTracking().Where(x => x.Id == id)
                .Include(x => x.Movie)
                .Include(x => x.Theater)
                .FirstOrDefaultAsync();
            return showtime;
        }


        public async Task<bool> HasReservationsAsync(int showtimeId)
        {
            return await _showtimeRepository.GetTableNoTracking()
                .Where(s => s.Id == showtimeId)
                .Select(s => s.Reservations!.Any())
                .FirstOrDefaultAsync();
        }

        public async Task<string> DeleteShowtimeAsync(Showtime showtime)
        {
            if (await HasReservationsAsync(showtime.Id))
                return "HasReservations";
            await _showtimeRepository.DeleteAsync(showtime);
            return "Success";
        }

        #endregion
    }
}
