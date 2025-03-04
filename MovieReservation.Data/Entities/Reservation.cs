using MovieReservation.Data.Entities.Identity;
namespace MovieReservation.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public int SeatNumber { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string SecretCode { get; set; }
        public int AppUserId { get; set; }
        public int ShowtimeId { get; set; }
        public AppUser? AppUser { get; set; }
        public Showtime? Showtime { get; set; }
    }
}
