using Luxe.Models;
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

        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "All Product Category";
        //    //return View(_productRepository.AllProducts);
        //    ProductListViewModel productListViewModel = new ProductListViewModel(_productRepository.AllProducts, "All Product Category");
        //    return View(productListViewModel);  
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Product> products;
            string? currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                products = _productRepository.AllProducts.OrderBy(p => p.Id);
                currentCategory = "All products";
            }
            else
            {
                products = _productRepository.AllProducts.Where(p => p.Category.Name == category).OrderBy(p => p.Id);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.Name == category)?.Name;
            }

            return View(new ProductListViewModel(products, currentCategory));
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
