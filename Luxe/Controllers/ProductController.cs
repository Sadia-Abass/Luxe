using Luxe.Repositories;
using Luxe.ViewModels;
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
            //ViewBag.CurrentCategory = "All Product Category";
            //return View(_productRepository.AllProducts);
            ProductListViewModel productListViewModel = new ProductListViewModel(_productRepository.AllProducts, "All Product Category");
            return View(productListViewModel);  
        }

        public IActionResult Details(int id) 
        {
            var product = _productRepository.GetProductById(id);
            if(product == null)
            {
                return NotFound();
            }
            return View(product);   
        }
    }
}
