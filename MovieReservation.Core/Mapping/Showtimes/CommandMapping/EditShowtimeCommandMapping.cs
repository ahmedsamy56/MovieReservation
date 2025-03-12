using MovieReservation.Core.Features.Showtimes.Commands.Models;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfile
    {
        public void EditShowtimeCommandMapping()
        {
            CreateMap<EditShowtimeCommand, Showtime>()
                      .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieNumber))
                      .ForMember(dest => dest.TheaterId, opt => opt.MapFrom(src => src.TheaterNumber));
        }
    }
}
