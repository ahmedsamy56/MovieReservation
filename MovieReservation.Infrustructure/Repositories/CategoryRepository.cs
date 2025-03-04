using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Infrustructure.Context;
using MovieReservation.Infrustructure.GenericRepository;

namespace MovieReservation.Infrustructure.Repositories
{
    public class CategoryRepository : GenericRepositoryAsync<Category>, ICategoryRepository
    {
        #region Fields
        private readonly DbSet<Category> _categories;
        #endregion

        #region Constructors
        public CategoryRepository(AppDbContext dbContext) : base(dbContext)
        {
            _categories = dbContext.Set<Category>();
        }
        #endregion


        #region Functions
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categories.ToListAsync();
        }
        #endregion

    }
}
