using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Abstracts
{
    public interface IReservationRepository : IGenericRepositoryAsync<Reservation>
    {

    }
}
