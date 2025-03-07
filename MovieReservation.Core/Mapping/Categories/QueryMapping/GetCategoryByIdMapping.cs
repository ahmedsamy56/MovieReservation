using MovieReservation.Core.Features.Categories.Queries.Results;
using MovieReservation.Data.Entities;

namespace MovieReservation.Core.Mapping.Categories
{
    public partial class CategoryProfile
    {
        public void GetCategoryByIdMapping()
        {
            CreateMap<Category, GetCategoryByIdResponse>()
                 .ForMember(dest => dest.Movies, opt => opt.MapFrom(src => src.Movies ?? new List<Movie>()));

            CreateMap<Movie, MovieList>()
                .ForMember(dest => dest.PosterUrl, opt => opt.MapFrom(src => src.Poster))
                .ForMember(dest => dest.releaseDate, opt => opt.MapFrom(src => src.releaseDate));

        }
    }
}
