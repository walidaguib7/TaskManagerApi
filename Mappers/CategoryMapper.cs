using TasksApi.Dtos.Category;
using TasksApi.Models;

namespace TasksApi.Mappers
{
    public static class CategoryMapper
    {
        public static Category ToCategory(this CreateCategoryDto dto)
        {
            return new Category
            {
                Name = dto.Name
            };
        }
    }
}
