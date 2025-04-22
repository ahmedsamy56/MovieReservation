using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Data.Helpers;

namespace MovieReservation.Infrustructure.Seeder
{
    public static class UserSeeder
    {
        public static async Task SeedAsync(UserManager<AppUser> _userManager)
        {
            var usersCount = await _userManager.Users.CountAsync();
            if (usersCount <= 0)
            {
                var defaultuser = new AppUser()
                {
                    UserName = "admin@admin.com",
                    Name = "Admin",
                    Email = "admin@admin.com",
                    PhoneNumber = "01205926527",
                    Birthday = new DateOnly(2004, 6, 5),
                    EmailConfirmed = true,
                    PhoneNumberConfirmed = true
                };
                await _userManager.CreateAsync(defaultuser, "Admin@123");
                await _userManager.AddToRoleAsync(defaultuser, SD.AdminRole);
            }
        }
    }
}
