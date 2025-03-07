using MovieReservation.Core.Features.Movies.Commands.Models;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Movies
{
    public partial class MovieProfile
    {

        public void EditMovieCommandMapping()
        {
            CreateMap<EditMovieCommand, Movie>()
                  .ForMember(dest => dest.CategoryId, opt => opt.MapFrom(src => src.CategoryNumber))
                  .ForMember(dest => dest.CreatedAt, opt => opt.Ignore())
                  .ForMember(dest => dest.Poster, opt => opt.Ignore());
        }
    }
}
