namespace MovieReservation.Data.Entities
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Poster {  get; set; }
        public int DurationInMinutes { get; set; }
        public int SuitableAge { get; set; }
        public DateOnly releaseDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int CategoryId { get; set; }
        public Category? Category { get; set; }
    }
}
