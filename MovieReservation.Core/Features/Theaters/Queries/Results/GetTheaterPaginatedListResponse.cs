namespace MovieReservation.Core.Features.Theaters.Queries.Results
{
    public class GetTheaterPaginatedListResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int totalSeats { get; set; }
    }
}
