using AutoMapper;

namespace MovieReservation.Core.Mapping.Movies
{
    public partial class MovieProfile : Profile
    {

        public MovieProfile()
        {
            //command
            AddMovieCommandMapping();
            EditMovieCommandMapping();


            //Query
            GetMovieByIdQueryMapping();
            GetMoviesPaginatedListMapping();

        }
    }
}
