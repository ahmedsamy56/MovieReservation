using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Repositories
{
    public class ShowtimeRepository : GenericRepositoryAsync<Showtime>, IShowtimeRepository
    {
        #region Fields
        private readonly DbSet<Showtime> _showtimes;
        #endregion


        #region Constructors
        public ShowtimeRepository(AppDbContext dbContext) : base(dbContext)
        {
            _showtimes = dbContext.Set<Showtime>();
        }
        #endregion


        #region Functions
        #endregion
    }
}
