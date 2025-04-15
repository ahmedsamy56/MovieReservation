using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Helpers;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class CurrentUserService : ICurrentUserService
    {

        #region Fields
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserManager<AppUser> _userManager;
        #endregion
        #region Constructors
        public CurrentUserService(IHttpContextAccessor httpContextAccessor, UserManager<AppUser> userManager)
        {
            _httpContextAccessor = httpContextAccessor;
            _userManager = userManager;
        }
        #endregion
        #region Functions
        public int GetUserId()
        {
            var userId = _httpContextAccessor.HttpContext.User.Claims.SingleOrDefault(claim => claim.Type == nameof(UserClaimModel.Id)).Value;
            if (userId == null)
            {
                throw new UnauthorizedAccessException();
            }
            return int.Parse(userId);
        }

        public async Task<AppUser> GetUserAsync()
        {
            var userId = GetUserId();
            var user = await _userManager.FindByIdAsync(userId.ToString());
            if (user == null)
            { throw new UnauthorizedAccessException(); }
            return user;
        }

        public async Task<List<string>> GetCurrentUserRolesAsync()
        {
            var user = await GetUserAsync();
            var roles = await _userManager.GetRolesAsync(user);
            return roles.ToList();
        }
        #endregion
    }
}
