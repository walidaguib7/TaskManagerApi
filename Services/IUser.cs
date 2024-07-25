using TasksApi.Dtos;
using TasksApi.Dtos.User;
using TasksApi.Models;

namespace TasksApi.Services
{
    public interface IUser
    {
        public Task<User?> CreateAccount(User _user, string Password);
        public Task<NewUser> Login(LoginDto dto); 
    }
}
