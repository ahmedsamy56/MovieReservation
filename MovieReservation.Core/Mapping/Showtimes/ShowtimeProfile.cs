using AutoMapper;

namespace MovieReservation.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfile : Profile
    {
        public ShowtimeProfile()
        {
            AddShowtimeCommandMapping();
            EditShowtimeCommandMapping();

            GetShowtimePaginatedListMapping();
            GetShowtimeByIdQueryMapping();

        }
    }
}
