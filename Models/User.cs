using Microsoft.AspNetCore.Identity;

namespace TasksApi.Models
{
    public class User : IdentityUser
    {

        public string first_name { get; set; }
        public string last_name { get; set; }
        public string? bio { get; set; }
        public string gender { get; set; }

        public int fileId { get; set; }
        public FilesModel file { get; set; }
    }
}
