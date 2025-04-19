using MovieReservation.Core.Features.Reservations.Commands.Models;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Reservations
{
    public partial class ReservationProfile
    {
        public void AddReservationCommandMapping()
        {
            CreateMap<AddReservationCommand, Reservation>()
                   .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => DateTime.Now))
                   .ForMember(dest => dest.SecretCode, opt => opt.MapFrom(src => Guid.NewGuid().ToString().Substring(0, 8)));
        }
    }
}
