namespace MovieReservation.Core.Features.Movies.Queries.Results
{
    public class GetMovieByIdResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string PosterUrl { get; set; }
        public int DurationInMinutes { get; set; }
        public int SuitableAge { get; set; }
        public DateOnly releaseDate { get; set; }
        public DateTime CreatedAt { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

    }
}
