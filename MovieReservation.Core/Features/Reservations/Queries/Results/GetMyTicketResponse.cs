namespace MovieReservation.Core.Features.Reservations.Queries.Results
{
    public class GetMyTicketResponse
    {
        public string UserName { get; set; }
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public DateTime StartTime { get; set; }
        public string ValidationLink { get; set; }
    }
}
