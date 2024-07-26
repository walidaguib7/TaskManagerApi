using FluentValidation;
using TasksApi.Models;

namespace TasksApi.Validation
{
    public class UserValidator : AbstractValidator<User>
    {
        public UserValidator() { 
        
            RuleFor(user => user.Email)
                .NotEmpty().EmailAddress().NotNull()
                .WithMessage("Email should be unique and in valid format.")
                ;
            RuleFor(user => user.UserName)
                .NotEmpty().MinimumLength(20).NotNull()
                .WithMessage("Username should have at least 20 caracters or more");
            RuleFor(user => user.first_name)
                .NotEmpty().MinimumLength(20).NotNull()
                .WithMessage("Username should have at least 20 caracters or more"); ;
            RuleFor(user => user.last_name)
                .NotEmpty().MinimumLength(20).NotNull()
                .WithMessage("Username should have at least 20 caracters or more"); ;
            RuleFor(user => user.gender)
                .NotEmpty().NotNull()
                .WithMessage("Gender must me female or male");
            RuleFor(user => user.fileId)
                .NotEqual(0).NotNull().WithMessage("Id must be a numeric value");

        }
    }
}
