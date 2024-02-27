using Luxe.Models;

namespace Luxe.Repositories
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category>
        {
            new Category { Id = 1, Name = "Skin Care", Description = "The use of cosmetics to care for the skin."},
            new Category { Id = 2, Name = "Make Up", Description = "A type of cosmetics (such as lipstick, mascara, and eye shadow) used to color and beautify the face."},
            new Category { Id = 3, Name = "Toiletries", Description = " Are objects and substances that you use in washing yourself and preventing the body from smelling unpleasant"}
        };
    }
}
