namespace MovieReservation.Core.Features.AppUsers.Queries.Results
{
    public class GetAppUserPaginationReponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
