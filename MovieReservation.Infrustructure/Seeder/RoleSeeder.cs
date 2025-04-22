using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Helpers;

namespace MovieReservation.Infrustructure.Seeder
{
    public static class RoleSeeder
    {
        public static async Task SeedAsync(RoleManager<Role> _roleManager)
        {
            var rolesCount = await _roleManager.Roles.CountAsync();
            if (rolesCount <= 0)
            {

                await _roleManager.CreateAsync(new Role()
                {
                    Name = SD.AdminRole
                });
                await _roleManager.CreateAsync(new Role()
                {
                    Name = SD.UserRole
                });
            }
        }
    }
}
