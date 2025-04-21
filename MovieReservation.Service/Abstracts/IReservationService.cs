using MovieReservation.Data.Entities;
using MovieReservation.Data.Enums;
using MovieReservation.Data.Helpers;

namespace MovieReservation.Service.Abstracts
{
    public interface IReservationService
    {
        Task<bool> IsSeatTakenAsync(int showtimeId, int seatNumber);
        public Task<string> AddReservationAsync(Reservation reservation);
        public Task<Reservation> GetReservationByIdWithIncludeAsync(int id);
        public Task<string> DeleteReservationAsync(int reservationId);
        public Task<string> ValidateReservationAsync(string code);
        public IQueryable<Reservation> FilterReservationPaginatedQuerable(ReservayionOrderingEnum orderingEnum, string search);
        public Task<int> GetReservationsCountAsync();
        Task<ReservationStatsResponse> GetReservationStatsAsync(DateTime? from, DateTime? to);


    }
}
