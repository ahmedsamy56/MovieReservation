namespace MovieReservation.Core.Features.Authorization.Queries.Results
{
    public class GetAllAdminsResponse
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public DateOnly Birthday { get; set; }
    }
}
