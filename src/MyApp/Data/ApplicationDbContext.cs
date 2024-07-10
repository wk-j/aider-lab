using Microsoft.EntityFrameworkCore;

namespace MyApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Add DbSet properties for your entities here
        // For example:
        // public DbSet<YourEntity> YourEntities { get; set; }
    }
}
