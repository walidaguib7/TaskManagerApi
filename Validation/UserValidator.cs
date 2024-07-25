using FluentValidation;
using TasksApi.Models;

namespace TasksApi.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() { 
        
            RuleFor(user => user.Email)
                .NotEmpty().EmailAddress().NotNull();
            RuleFor(user => user.UserName)
                .NotEmpty().MinimumLength(20).NotNull();
            RuleFor(user => user.first_name)
                .NotEmpty().MinimumLength(20).NotNull();
            RuleFor(user => user.last_name)
                .NotEmpty().MinimumLength(20).NotNull();
            RuleFor(user => user.gender)
                .NotEmpty().NotNull();
            RuleFor(user => user.fileId)
                .NotEqual(0).NotNull();

        }
    }
}
