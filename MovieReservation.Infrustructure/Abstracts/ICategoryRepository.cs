using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Abstracts
{
    public interface ICategoryRepository : IGenericRepositoryAsync<Category>
    {
        public Task<List<Category>> GetCategoriesAsync();
    }
}
