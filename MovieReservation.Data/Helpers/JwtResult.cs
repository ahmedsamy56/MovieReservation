namespace MovieReservation.Data.Helpers
{
    public class JwtResult
    {
        public string AccessToken { get; set; }
        public RefreshToken refreshToken { get; set; }
    }
    public class RefreshToken
    {
        public string Email { get; set; }
        public string TokenString { get; set; }
        public DateTime ExpireAt { get; set; }
    }
}
