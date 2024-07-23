using System.ComponentModel.DataAnnotations;

namespace TasksApi.Dtos.Category
{
    public class CreateCategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}
