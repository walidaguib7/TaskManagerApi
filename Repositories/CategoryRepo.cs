using FluentValidation;
using Microsoft.EntityFrameworkCore;
using TasksApi.Data;
using TasksApi.Dtos.Category;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Repositories
{
    public class CategoryRepo(
        ApplicationDBContext _context , 
        [FromKeyedServices("category")] IValidator<Category> _validator) : ICategory
    {
        private readonly ApplicationDBContext context = _context;
        private readonly IValidator<Category> validator = _validator;
        public async Task<Category?> CreateCategory(Category category)
        {
            var result = validator.Validate(category);
            if (result.IsValid) {
                await context.categories.AddAsync(category);
                await context.SaveChangesAsync();
                return category;
            }else
            {
                throw new ValidationException(result.Errors);
            }
            
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
            var result = validator.Validate(category);
            if (result.IsValid)
            {
                category.Name = dto.Name;
                await context.SaveChangesAsync();
                return category;
            }else
            {
                throw new ValidationException(result.Errors);
            }
        }
    }
}
