using MovieReservation.Core.Features.Movies.Queries.Results;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Movies
{
    public partial class MovieProfile
    {
        public void GetMovieByIdQueryMapping()
        {
            CreateMap<Movie, GetMovieByIdResponse>()
                    .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.Poster))
                    .ForMember(dest => dest.CategoryName, opt => opt.MapFrom(src => src.Category != null ? src.Category.Name : string.Empty));
        }
    }
}
