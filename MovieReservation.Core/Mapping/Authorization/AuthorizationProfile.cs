using AutoMapper;

namespace MovieReservation.Core.Mapping.Authorization
{
    public partial class AuthorizationProfile : Profile
    {
        public AuthorizationProfile()
        {
            GetAllAdminsMapping();
        }
    }
}
