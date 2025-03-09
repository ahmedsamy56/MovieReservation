namespace MovieReservation.Core.Features.Theaters.Queries.Results
{
    public class GetTheaterByIdResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int totalSeats { get; set; }
        public List<ShowTimeList>? showTimeList { get; set; }
    }

    public class ShowTimeList
    {
        public int Id { get; set; }
        public decimal Price { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int MovieId { get; set; }
        public string MovieTitle { get; set; }
        public string MoviePoster { get; set; }
    }
}
