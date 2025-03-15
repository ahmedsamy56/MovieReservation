using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Service.Abstracts
{
    public interface IAppUserService
    {
        public Task<string> AddUserAsync(AppUser user, string password);
    }
}
