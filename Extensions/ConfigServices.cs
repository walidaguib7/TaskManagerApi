using FluentValidation;
using Microsoft.AspNetCore.Identity;
using TasksApi.Data;
using TasksApi.Models;
using TasksApi.Repositories;
using TasksApi.Services;
using TasksApi.Validation;

namespace TasksApi.Extensions
{
    public static class ConfigServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IFiles, FilesRepo>();
            services.AddTransient<IToken, TokenRepo>();
            services.AddScoped<IUser, UserRepo>();
            services.AddTransient<ICategory, CategoryRepo>();
            services.AddTransient<ITasks, TasksRepo>();

            services.AddKeyedScoped<IValidator<User>, UserValidator>("user");
            services.AddKeyedScoped<IValidator<Category>,CategoryValidator>("category");
            services.AddKeyedScoped<IValidator<Tasks>, TasksValidator>("tasks");

            

        }

        public static void ConfigIdentity(this IServiceCollection services) 
        {

            services.AddIdentity<User, IdentityRole>
                (
                   options => 
                   {
                       options.Password.RequireDigit = true;
                       options.Password.RequireLowercase = true;
                       options.Password.RequiredLength = 12;
                       options.User.RequireUniqueEmail = true;

                   }
                ).AddEntityFrameworkStores<ApplicationDBContext>();
        }

        public static void AddSockets(this IServiceCollection services)
        {
            services.AddSignalR();
        }
    }
}
