using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TasksApi.Dtos.User;
using TasksApi.Helpers;
using TasksApi.Models;
using TasksApi.Services;

namespace TasksApi.Repositories
{
    public class UserRepo : IUser
    {
        private readonly UserManager<User> userManager ;
        private readonly IToken _tokenService ;
        private readonly SignInManager<User> manager;
        private readonly IValidator<User> validator  ;

        public UserRepo(
            UserManager<User> userManager,
            IToken tokenService,
            SignInManager<User> manager,
            [FromKeyedServices("user")] IValidator<User> _validator
            )
        {
            this.userManager = userManager;
            _tokenService = tokenService;
            this.manager = manager;
            validator = _validator;
            
    }

        public async Task<User?> CreateAccount(User _user , string Password)
        {
            var result =  validator.Validate(_user);
            if (result.IsValid)
            {
                await userManager.CreateAsync(_user, Password);
                return _user;
            }else
            {
                throw new ValidationException(result.Errors);
            }
             
            
        }

        public async Task<NewUser> Login(LoginDto dto)
        {
            var user = await userManager.Users
                .Include(u => u.file)
                .FirstOrDefaultAsync(u => u.Email == dto.Email);
            var ValidationResult = validator.Validate(user);
            if (!ValidationResult.IsValid)
            {
                throw new ValidationException(ValidationResult.Errors);
            }
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
