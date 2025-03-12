using MovieReservation.Core.Features.Showtimes.Queries.Results;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Showtimes
{
    public partial class ShowtimeProfile
    {
        public void GetShowtimeByIdQueryMapping()
        {
            CreateMap<Showtime, GetShowtimeByIdResponse>()
                   .ForMember(dest => dest.MovieName, opt => opt.MapFrom(src => src.Movie.Title))
                   .ForMember(dest => dest.MoviePoster, opt => opt.MapFrom(src => src.Movie.Poster))
                   .ForMember(dest => dest.TheaterName, opt => opt.MapFrom(src => src.Theater.Name));
        }
    }
}
