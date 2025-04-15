using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Service.Abstracts
{
    public interface ICurrentUserService
    {
        public Task<AppUser> GetUserAsync();
        public int GetUserId();
        public Task<List<string>> GetCurrentUserRolesAsync();
    }
}
