using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasksApi.Dtos.User;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Repositories
{
    public class UserRepo : IUser
    {
        private readonly UserManager<User> userManager ;
        private readonly IToken _tokenService ;
        private readonly SignInManager<User> manager;

        public UserRepo(UserManager<User> userManager, IToken tokenService, SignInManager<User> manager)
        {
            this.userManager = userManager;
            _tokenService = tokenService;
            this.manager = manager;
        }

        public async Task<User> CreateAccount(User _user)
        {
             await userManager.CreateAsync(_user);
            return _user;
            
        }

        public async Task<NewUser> Login(LoginDto dto)
        {
            var user = await userManager.Users
                .Include(u => u.file)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (user == null) return null;
            var result = await manager.CheckPasswordSignInAsync(user, dto.Password, false);

            return new NewUser
            {
                Id = user.Id,
                Email = dto.Email,
                username = user.UserName,
                token = _tokenService.CreateToken(user),
                ImagePath = user.file.Path
            };
        }
    }
}
