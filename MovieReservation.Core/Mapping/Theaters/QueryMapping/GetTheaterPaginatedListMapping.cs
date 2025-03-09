using MovieReservation.Core.Features.Theaters.Queries.Results;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Theaters
{
    public partial class TheaterProfile
    {
        public void GetTheaterPaginatedListMapping()
        {
            CreateMap<Theater, GetTheaterPaginatedListResponse>();

        }
    }
}
