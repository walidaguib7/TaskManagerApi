using System.ComponentModel.DataAnnotations;

namespace TasksApi.Dtos.User
{
    public class NewUser
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string username { get; set; }
        public string ImagePath { get; set; }
        public string token { get; set; }
    }
}
