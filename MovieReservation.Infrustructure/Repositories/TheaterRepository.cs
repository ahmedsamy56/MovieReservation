using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Repositories
{
    public class TheaterRepository : GenericRepositoryAsync<Theater>, ITheaterRepository
    {
        #region Fields
        private readonly DbSet<Theater> _theaters;
        #endregion


        #region Constructors
        public TheaterRepository(AppDbContext dbContext) : base(dbContext)
        {
            _theaters = dbContext.Set<Theater>();
        }
        #endregion


        #region Functions
        #endregion
    }
}
