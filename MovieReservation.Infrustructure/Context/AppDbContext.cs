using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Infrustructure.Context
{
    public class AppDbContext : IdentityDbContext<AppUser, Role, int, IdentityUserClaim<int>, IdentityUserRole<int>, IdentityUserLogin<int>, IdentityRoleClaim<int>, IdentityUserToken<int>>
    {

        
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<AppUser> appUsers { get; set; }
        public DbSet<Category> categories { get; set; }  
        public DbSet<Movie> movies { get; set; }
        public DbSet<Reservation> reservations { get; set; }    
        public DbSet<Showtime> showtimes { get; set; }
        public DbSet<Theater> theaters { get; set; }

    }
}
