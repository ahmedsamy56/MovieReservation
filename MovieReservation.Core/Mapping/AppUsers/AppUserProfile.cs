using AutoMapper;

namespace MovieReservation.Core.Mapping.AppUsers
{
    public partial class AppUserProfile : Profile
    {
        public AppUserProfile()
        {
            AddAppUserMapping();
        }
    }
}
