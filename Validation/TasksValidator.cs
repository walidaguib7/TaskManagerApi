using FluentValidation;

using TasksApi.Models;

namespace TasksApi.Validation
{
    public class TasksValidator : AbstractValidator<Tasks>
    {
        public TasksValidator()
        {
            RuleFor(t => t.Name)
                .NotEmpty().NotNull().MinimumLength(8);
            RuleFor(t => t.Description)
                .NotNull().NotEmpty().MaximumLength(120);
            RuleFor(t => t.status)
                .NotNull().NotEmpty();
            RuleFor(t => t.priority)
                .NotNull().NotEmpty();
            RuleFor(t => t.CreatedAt)
                .NotNull();
            RuleFor(t => t.categoryId)
                .NotNull().NotEqual(0).GreaterThan(0).NotEmpty();
            RuleFor(t => t.userId)
                .NotNull().NotEmpty();

        }
    }
}
