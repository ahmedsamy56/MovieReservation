namespace MovieReservation.Core.Features.Showtimes.Queries.Results
{
    public class GetShowtimePaginatedListResponse
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public int MovieId { get; set; }
        public string MovieName { get; set; }
        public string MoviePoster { get; set; }
        public int TheaterId { get; set; }
        public string TheaterName { get; set; }
    }
}
