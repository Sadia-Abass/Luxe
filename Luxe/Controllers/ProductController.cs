using Luxe.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Luxe.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly ICategoryRepository _categoryRepository;

        public ProductController(IProductRepository productRepository, ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List()
        {
            return View(_productRepository.AllProducts);
        }
    }
}
