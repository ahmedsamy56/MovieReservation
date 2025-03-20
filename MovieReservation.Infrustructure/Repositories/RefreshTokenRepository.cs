using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities.Identity;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Repositories
{
    public class RefreshTokenRepository : GenericRepositoryAsync<UserRefreshToken>, IRefreshTokenRepository
    {

        #region Fields
        private DbSet<UserRefreshToken> userRefreshToken;
        #endregion

        #region Constructors
        public RefreshTokenRepository(AppDbContext dbContext) : base(dbContext)
        {
            userRefreshToken = dbContext.Set<UserRefreshToken>();
        }
        #endregion

        #region Functions

        #endregion
    }
}
