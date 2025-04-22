using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Results;

namespace MovieReservation.Service.Abstracts
{
    public interface IAuthorizationService
    {
        public Task<string> AddAdminRole(int Id);
        public Task<string> RemoveAdminRole(int Id);

        public Task<List<AppUser>> GetAllAdminsAsync();
        Task<GetUserRoleRespons> GetUserRolesAsync(AppUser user);


    }
}
