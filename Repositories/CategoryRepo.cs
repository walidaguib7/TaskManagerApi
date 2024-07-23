using Microsoft.EntityFrameworkCore;
using TasksApi.Data;
using TasksApi.Dtos.Category;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Repositories
{
    public class CategoryRepo(ApplicationDBContext _context) : ICategory
    {
        private readonly ApplicationDBContext context = _context;
        public async Task<Category> CreateCategory(Category category)
        {
            await context.categories.AddAsync(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await context.categories.FindAsync(id);
            if (category == null) return null;
            context.categories.Remove(category);
            await context.SaveChangesAsync();
            return category;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await context.categories.ToListAsync();
        }

        public async Task<Category?> GetCategory(int id)
        {
            var category = await context.categories
                .FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return null;
            return category;
        }

        public async Task<Category?> UpdateCategory(int id, UpdateCategoryDto dto)
        {
            var category = await context.categories.FirstOrDefaultAsync(c => c.Id == id);
            if (category == null) return null;

            category.Name = dto.Name;
            await context.SaveChangesAsync();
            return category;
        }
    }
}
