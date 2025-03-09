using MovieReservation.Core.Features.Theaters.Queries.Results;
using MovieReservation.Data.Entities;


namespace MovieReservation.Core.Mapping.Theaters
{
    public partial class TheaterProfile
    {
        public void GetTheaterByIdQueryMapping()
        {
            CreateMap<Theater, GetTheaterByIdResponse>()
            .ForMember(dest => dest.showTimeList, opt => opt.MapFrom(src => src.Showtimes));

            CreateMap<Showtime, ShowTimeList>()
                .ForMember(dest => dest.MovieTitle, opt => opt.MapFrom(src => src.Movie.Title))
                .ForMember(dest => dest.MoviePoster, opt => opt.MapFrom(src => src.Movie.Poster))
                .ForMember(dest => dest.EndTime, opt => opt.MapFrom(src => src.StartTime.AddMinutes(src.Movie.DurationInMinutes)));

        }
    }
}
