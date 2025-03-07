using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Abstracts
{
    public interface IMovieRepository : IGenericRepositoryAsync<Movie>
    {

    }
}
