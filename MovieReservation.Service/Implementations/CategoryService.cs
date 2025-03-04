using Microsoft.EntityFrameworkCore;
using MovieReservation.Data.Entities;
using MovieReservation.Infrustructure.Abstracts;
using MovieReservation.Service.Abstracts;

namespace MovieReservation.Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        #region Fields
        private readonly ICategoryRepository _categoryRepository;
        #endregion

        #region Constructors
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        #endregion


        #region Functions
        public async Task<List<Category>> GetCategoriesAsync()
        {
            return await _categoryRepository.GetCategoriesAsync();
        }

        public async Task<Category> GetCategoryByIdWithIncludeAsync(int id)
        {
            var category = await _categoryRepository.GetTableNoTracking().Include(x => x.Movies).Where(x => x.Id == id).FirstOrDefaultAsync();
            return category;
        }

        public async Task<string> AddAsync(Category category)
        {
            await _categoryRepository.AddAsync(category);
            return "Success";
        }

        public async Task<bool> CategoryExistAsync(int id)
        {
            var Category = await _categoryRepository.GetByIdAsync(id);
            return Category != null;
        }

        public async Task<string> EditCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateAsync(category);
            return "Success";
        }

        public async Task<string> DeleteCategoryAsync(Category category)
        {
            await _categoryRepository.DeleteAsync(category);
            return "Success";
        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetByIdAsync(id);
            return category;
        }




        #endregion
    }
}
