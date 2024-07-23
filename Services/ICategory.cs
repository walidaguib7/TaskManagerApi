using TasksApi.Dtos.Category;
using TasksApi.Models;

namespace TasksApi.Services
{
    public interface ICategory
    {
        public Task<List<Category>> GetAllCategories(); 
        public Task<Category?> GetCategory(int id);
        public Task<Category> CreateCategory(Category category);
        public Task<Category?> UpdateCategory(int id , UpdateCategoryDto dto);
        public Task<Category?> DeleteCategory(int id);
    }
}
