namespace MovieReservation.Core.Features.Reporting.Queries.Results
{
    public class OverallReportingResponse
    {
        public int UsersNumber { get; set; }
        public int ReservationsNumber { get; set; }
        public int ShowtimesNumber { get; set; }
        public int TheatersNumber { get; set; }
        public int MoviesNumber { get; set; }
        public int CategoriesNumber { get; set; }
    }
}
