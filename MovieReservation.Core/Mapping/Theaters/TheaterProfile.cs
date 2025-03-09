using AutoMapper;

namespace MovieReservation.Core.Mapping.Theaters
{
    public partial class TheaterProfile : Profile
    {
        public TheaterProfile()
        {
            //command
            AddTheaterCommandMapping();
            EditTheaterCommandMapping();

            //Query
            GetTheaterByIdQueryMapping();
            GetTheaterPaginatedListMapping();
        }
    }
}
