using AuthProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AuthProject.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext (DbContextOptions<AppDbContext>options)
            : base(options)
        {

        }
        public DbSet<Student>students { get;set; }
        public DbSet<Role> roles { get;set; }
        public DbSet<ImageUpload>Images { get;set; }

    }

}
