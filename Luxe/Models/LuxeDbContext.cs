using Microsoft.EntityFrameworkCore;

namespace Luxe.Models
{
    public class LuxeDbContext : DbContext
    {
        public LuxeDbContext(DbContextOptions<LuxeDbContext> options) : base(options)
        {         
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
