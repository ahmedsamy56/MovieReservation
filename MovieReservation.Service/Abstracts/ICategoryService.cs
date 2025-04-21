using MovieReservation.Data.Entities;

namespace MovieReservation.Service.Abstracts
{
    public interface ICategoryService
    {
        public Task<List<Category>> GetCategoriesAsync();
        public Task<Category> GetCategoryByIdAsync(int id);
        public Task<Category> GetCategoryByIdWithIncludeAsync(int id);
        public Task<string> AddAsync(Category category);
        public Task<bool> CategoryExistAsync(int id);
        public Task<string> EditCategoryAsync(Category category);
        public Task<string> DeleteCategoryAsync(Category category);
        public Task<int> GetCategoriesCountAsync();
    }
}
