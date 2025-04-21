namespace MovieReservation.Core.Features.Reservations.Queries.Results
{
    public class GetReservationPaginatedListResponse
    {
        public string UserName { get; set; }
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime CreatedAt { get; set; }
        public decimal Price { get; set; }
    }
}
