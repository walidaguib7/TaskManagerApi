using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TasksApi.Helpers;
using TasksApi.Models;

namespace TasksApi.Data
{
    public class ApplicationDBContext : IdentityDbContext<User>
    {
        public ApplicationDBContext(DbContextOptions options) : base(options)
        {
            
        }



        public DbSet<FilesModel> files { get; set; }
        public DbSet<Category> categories { get; set; }
        public DbSet<Tasks> tasks { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tasks>()
                .Property(t => t.status)
                .HasConversion
                (
                  v => v.ToString(),
                  v => Enum.Parse<Status>(v)
                );
            builder.Entity<Tasks>()
                .Property(t => t.priority)
                .HasConversion
                (
                  v => v.ToString(),
                  v => Enum.Parse<Priority>(v)
                );
        }
    }
}
