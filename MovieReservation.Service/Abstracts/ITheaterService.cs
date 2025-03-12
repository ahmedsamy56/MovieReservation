using MovieReservation.Data.Entities;
using MovieReservation.Data.Enums;

namespace MovieReservation.Service.Abstracts
{
    public interface ITheaterService
    {
        public Task<string> AddTheaterAsync(Theater theater);
        public Task<string> EditTheaterAsync(Theater theater);
        public Task<Theater> GetTheaterByIdAsync(int id);
        public Task<Theater> GetTheaterByIdWithIncludeAsync(int id);
        public IQueryable<Theater> FilterTheaterPaginatedQuerable(TheaterOrderingEnum orderingEnum, string search);
        public Task<bool> HasShowtimesAsync(int theaterId);
        public Task<string> DeleteTheaterAsync(Theater theater);
        public Task<bool> TheaterExistsAsync(int id);
        public Task<bool> IsTheaterAvailableAsync(int theaterId, DateTime startTime, int movieId);
    }
}
