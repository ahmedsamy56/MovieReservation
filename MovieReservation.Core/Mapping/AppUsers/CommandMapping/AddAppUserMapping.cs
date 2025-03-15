using MovieReservation.Core.Features.AppUsers.Commands.Models;
using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Core.Mapping.AppUsers
{
    public partial class AppUserProfile
    {
        public void AddAppUserMapping()
        {
            CreateMap<AddAppUserCommand, AppUser>()
            .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.Email))
            .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
            .ForMember(dest => dest.Reservations, opt => opt.Ignore());
        }
    }
}
