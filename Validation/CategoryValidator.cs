﻿using FluentValidation;
using TasksApi.Models;

namespace TasksApi.Validation
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator() {

            RuleFor(c => c.Name)
                .NotEmpty().NotNull().WithName("category name shoudnit be null or empty");
        }
    }
}
