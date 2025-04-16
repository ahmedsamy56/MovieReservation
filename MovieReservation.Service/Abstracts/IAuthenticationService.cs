using System.IdentityModel.Tokens.Jwt;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Helpers;

namespace MovieReservation.Service.Abstracts
{
    public interface IAuthenticationService
    {
        public Task<JwtResult> GetJWTToken(AppUser appUser);
        public JwtSecurityToken ReadJWTToken(string accessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<JwtResult> GetRefreshToken(AppUser user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken);
        public Task<string> ValidateToken(string AccessToken);
        public Task<string> ConfirmEmail(int? userId, string? code);
    }
}
