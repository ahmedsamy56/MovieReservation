namespace MovieReservation.Data.Entities
{
    public class Showtime
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public Movie? Movie { get; set; }
        public Theater? Theater { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
