using Luxe.Models;

namespace Luxe.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
        Product? GetProductById(int id);
    }
}
