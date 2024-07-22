using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasksApi.Models;

namespace TasksApi.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }



        public DbSet<FilesModel> files { get; set; }
    }
}
