using Luxe.Models;

namespace Luxe.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly LuxeDbContext _luxeDbContext;

        public CategoryRepository(LuxeDbContext luxeDbContext)
        {
            _luxeDbContext = luxeDbContext;
        }

        public IEnumerable<Category> AllCategories => _luxeDbContext.Categories.OrderBy(p => p.Name);
    }
}
