using Luxe.Repositories;
using Luxe.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Luxe.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductRepository _productRepository;

        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index()
        {
            var popularProduct = _productRepository.AllProducts;
            var homeViewModel = new HomeViewModel(popularProduct);
            return View(homeViewModel);
        }
    }
}
