using System.ComponentModel.DataAnnotations;

namespace TasksApi.Dtos.User
{
    public class RegisterDto
    {
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
        public string username { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string first_name { get; set; }
        [Required]
        public string last_name { get; set; }
        [MaxLength(255)]
        [MinLength(40)]
        public string? bio { get; set; }
        [Required]
        public string gender { get; set; }
        [Required]
        public int fileId { get; set; }
    }
}
