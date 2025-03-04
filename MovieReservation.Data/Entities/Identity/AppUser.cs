using Microsoft.AspNetCore.Identity;

namespace MovieReservation.Data.Entities.Identity
{
    public class AppUser : IdentityUser<int>
    {
        public string Name { get; set; }
        public DateOnly Birthday { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Reservation>? Reservations { get; set; }
    }
}
