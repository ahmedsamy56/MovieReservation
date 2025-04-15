using MovieReservation.Core.Features.Authorization.Queries.Results;
using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Core.Mapping.Authorization
{
    public partial class AuthorizationProfile
    {
        public void GetAllAdminsMapping()
        {
            CreateMap<AppUser, GetAllAdminsResponse>();
        }
    }
}
