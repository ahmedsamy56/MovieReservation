using MovieReservation.Data.Entities.Identity;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Abstracts
{
    public interface IRefreshTokenRepository : IGenericRepositoryAsync<UserRefreshToken>
    {
    }
}
