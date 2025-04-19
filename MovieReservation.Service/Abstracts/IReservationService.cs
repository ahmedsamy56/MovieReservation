using MovieReservation.Data.Entities;

namespace MovieReservation.Service.Abstracts
{
    public interface IReservationService
    {
        Task<bool> IsSeatTakenAsync(int showtimeId, int seatNumber);
        public Task<string> AddReservationAsync(Reservation reservation);
        public Task<Reservation> GetReservationByIdWithIncludeAsync(int id);
        public Task<string> DeleteReservationAsync(int reservationId);
        public Task<string> ValidateReservationAsync(string code);

    }
}
