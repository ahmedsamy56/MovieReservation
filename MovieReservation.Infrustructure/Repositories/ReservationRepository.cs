using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Repositories
{
    public class ReservationRepository : GenericRepositoryAsync<Reservation>, IReservationRepository
    {


        #region Fields
        private readonly DbSet<Reservation> _reservation;
        #endregion


        #region Constructors
        public ReservationRepository(AppDbContext dbContext) : base(dbContext)
        {
            _reservation = dbContext.Set<Reservation>();
        }
        #endregion


        #region Functions
        #endregion
    }
}
