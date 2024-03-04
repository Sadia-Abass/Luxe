using Luxe.Models;
using Microsoft.EntityFrameworkCore;

namespace Luxe.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly LuxeDbContext _luxeDbcontext;

        public ProductRepository(LuxeDbContext luxeDbContext)
        {
            _luxeDbcontext = luxeDbContext;
        }

        public IEnumerable<Product> AllProducts
        {
            get
            {
                return _luxeDbcontext.Products.Include(c => c.Category);
            }
        }

        public Product? GetProductById(int id)
        {
            return _luxeDbcontext.Products.FirstOrDefault(p => p.Id == id);
        }
    }
}
