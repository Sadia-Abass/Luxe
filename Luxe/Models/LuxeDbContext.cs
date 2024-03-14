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
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }    
    }
}
