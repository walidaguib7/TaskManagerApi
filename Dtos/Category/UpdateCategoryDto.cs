using System.ComponentModel.DataAnnotations;

namespace TasksApi.Dtos.Category
{
    public class UpdateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
