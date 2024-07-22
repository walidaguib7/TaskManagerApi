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
    }
}
