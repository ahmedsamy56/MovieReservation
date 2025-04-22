using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Helpers;
using MovieReservation.Data.Results;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class AuthorizationService : IAuthorizationService
    {
        #region Fields
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<Role> _roleManager;
        #endregion

        #region Constructors
        public AuthorizationService(UserManager<AppUser> userManager, RoleManager<Role> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        #endregion


        #region Functions

        public async Task<string> AddAdminRole(int Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null)
                return "User not found.";

            if (await _userManager.IsInRoleAsync(user, SD.AdminRole))
                return "User is already in the Admin role.";

            var result = await _userManager.AddToRoleAsync(user, SD.AdminRole);

            return result.Succeeded ? "User added to Admin role." : "Failed to add user to Admin role.";
        }

        public async Task<string> RemoveAdminRole(int Id)
        {
            var user = await _userManager.FindByIdAsync(Id.ToString());
            if (user == null)
                return "User not found.";

            if (!await _userManager.IsInRoleAsync(user, SD.AdminRole))
                return "User is not in the Admin role.";

            var result = await _userManager.RemoveFromRoleAsync(user, SD.AdminRole);

            return result.Succeeded ? "User removed from Admin role." : "Failed to remove user from Admin role.";
        }

        public async Task<List<AppUser>> GetAllAdminsAsync()
        {
            var users = await _userManager.Users.ToListAsync();
            var admins = new List<AppUser>();

            foreach (var user in users)
            {
                if (await _userManager.IsInRoleAsync(user, SD.AdminRole))
                    admins.Add(user);
            }

            return admins;
        }

        public async Task<GetUserRoleRespons> GetUserRolesAsync(AppUser user)
        {
            var roles = await _userManager.GetRolesAsync(user);

            var userRolesList = new List<UserRoles>();

            foreach (var roleName in roles)
            {
                var role = await _roleManager.FindByNameAsync(roleName);
                if (role != null)
                {
                    userRolesList.Add(new UserRoles
                    {
                        Id = role.Id,
                        Name = role.Name
                    });
                }
            }

            var response = new GetUserRoleRespons
            {
                UserId = user.Id,
                userRoles = userRolesList
            };

            return response;
        }

        #endregion

    }
}
