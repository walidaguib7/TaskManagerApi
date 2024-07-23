using Microsoft.AspNetCore.Identity;
using TasksApi.Data;
using TasksApi.Models;
using TasksApi.Repositories;
using TasksApi.Services;

namespace TasksApi.Extensions
{
    public static class ConfigServices
    {
        public static void AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<IFiles, FilesRepo>();
            services.AddTransient<IToken, TokenRepo>();
            services.AddScoped<IUser, UserRepo>();
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
    }
}
