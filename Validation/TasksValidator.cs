using FluentValidation;
using Microsoft.VisualBasic;
using TasksApi.Models;

namespace TasksApi.Validation
{
    public class TasksValidator : AbstractValidator<Tasks>
    {
        public TasksValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty().NotNull().MinimumLength(8)
                .WithMessage("Name should has at least 8 caraters");
            RuleFor(t => t.Description)
                .NotNull().NotEmpty().MaximumLength(120)
                .WithMessage("Name should has max 120 caracters");
            RuleFor(t => t.CreatedAt)
                .NotNull().WithMessage("date should'nt be null or in invalid format!");
            RuleFor(t => t.Due_Date)
                .NotNull().WithMessage("date should'nt be null or in invalid format!"); ;
            RuleFor(t => t.categoryId)
                .NotNull().NotEqual(0).GreaterThan(0).NotEmpty()
                .WithMessage("Id must be a numeric value");
            RuleFor(t => t.userId)
                .NotNull().NotEmpty().WithMessage("Id must be a string value"); ;

        }
    }
}
