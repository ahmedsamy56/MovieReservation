using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddAdminRole(int Id);
        public Task<string> RemoveAdminRole(int Id);

        public Task<List<AppUser>> GetAllAdminsAsync();

    }
}
