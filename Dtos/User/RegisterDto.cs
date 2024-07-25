using System.ComponentModel.DataAnnotations;

namespace TasksApi.Dtos.User
{
    public class RegisterDto
    {

        public string Email { get; set; }

        public string username { get; set; }

        public string password { get; set; }
  
        public string first_name { get; set; }
 
        public string last_name { get; set; }

        public string? bio { get; set; }
 
        public string gender { get; set; }
        
        public int fileId { get; set; }
    }
}
