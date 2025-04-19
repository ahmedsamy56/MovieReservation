namespace MovieReservation.Core.Features.Reservations.Commands.Results
{
    public class Ticket
    {
        public string UserName { get; set; }
        public string MovieName { get; set; }
        public string TheaterName { get; set; }
        public DateTime StartTime { get; set; }
        public string ValidationLink { get; set; }

    }
}
