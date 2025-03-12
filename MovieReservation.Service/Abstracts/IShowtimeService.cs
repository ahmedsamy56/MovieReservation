using MovieReservation.Data.Entities;
using MovieReservation.Data.Enums;

namespace MovieReservation.Service.Abstracts
{
    public interface IShowtimeService
    {
        public Task<string> AddShowtimeAsync(Showtime showtime);
        public Task<string> EditShowtimeAsync(Showtime showtime);
        public Task<Showtime> GetShowtimeByIdAsync(int id);
        public IQueryable<Showtime> FilterShowtimePaginatedQuerable(ShowtimeOrderingEnum orderingEnum, string search, DateTime? startDate, DateTime? endDate);
        public Task<Showtime> GetShowtimeByIdWithIncludeAsync(int id);
        public Task<bool> HasReservationsAsync(int showtimeId);
        public Task<string> DeleteShowtimeAsync(Showtime showtime);

    }
}
