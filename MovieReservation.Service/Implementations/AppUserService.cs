using MovieReservation.Data.Entities.Identity;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class AppUserService : IAppUserService
    {
        public Task<string> AddUserAsync(AppUser user, string password)
        {
            throw new NotImplementedException();
        }
    }
}
