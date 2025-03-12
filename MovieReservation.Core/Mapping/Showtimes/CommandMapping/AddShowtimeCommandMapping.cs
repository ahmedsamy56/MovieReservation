using MovieReservation.Core.Features.Showtimes.Commands.Models;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfile
    {
        public void AddShowtimeCommandMapping()
        {
            CreateMap<AddShowtimeCommand, Showtime>()
                       .ForMember(dest => dest.MovieId, opt => opt.MapFrom(src => src.MovieNumber))
                       .ForMember(dest => dest.TheaterId, opt => opt.MapFrom(src => src.TheaterNumber));
        }
    }
}
