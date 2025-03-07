using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Repositories
{
    public class MovieRepository : GenericRepositoryAsync<Movie>, IMovieRepository
    {

        #region Fields
        private readonly DbSet<Movie> _movies;
        #endregion


        #region Constructors
        public MovieRepository(AppDbContext dbContext) : base(dbContext)
        {
            _movies = dbContext.Set<Movie>();
        }
        #endregion


        #region Functions
        #endregion

    }
}
