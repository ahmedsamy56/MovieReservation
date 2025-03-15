using MovieReservation.Core.Features.AppUsers.Queries.Results;
using MovieReservation.Data.Entities.Identity;

namespace MovieReservation.Core.Mapping.AppUsers
{
    public partial class AppUserProfile
    {
        public void GetAppUserByIdMapping()
        {
            CreateMap<AppUser, GetAppUserByIdResponse>();
        }
    }
}
