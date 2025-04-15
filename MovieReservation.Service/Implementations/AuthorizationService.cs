using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly UserManager<AppUser> _userManager;
        #endregion

        #region Constructors
        public AuthorizationService(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }


        #endregion


        #region Functions

        public async Task<string> AddAdminRole(int Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null)
                return "User not found.";

            if (await _userManager.IsInRoleAsync(user, "Admin"))
                return "User is already in the Admin role.";

            var result = await _userManager.AddToRoleAsync(user, "Admin");

            return result.Succeeded ? "User added to Admin role." : "Failed to add user to Admin role.";
        }

        public async Task<string> RemoveAdminRole(int Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null)
                return "User not found.";

            if (!await _userManager.IsInRoleAsync(user, "Admin"))
                return "User is not in the Admin role.";

            var result = await _userManager.RemoveFromRoleAsync(user, "Admin");

            return result.Succeeded ? "User removed from Admin role." : "Failed to remove user from Admin role.";
        }

        public async Task<List<AppUser>> GetAllAdminsAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var admins = new List<AppUser>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, "Admin"))
                    admins.Add(user);
            }

            return admins;
        }

        #endregion

    }
}
