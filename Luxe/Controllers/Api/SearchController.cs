using Luxe.Models;
using Luxe.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Luxe.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public SearchController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allProduct = _productRepository.AllProducts;
            return Ok(allProduct);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if(!_productRepository.AllProducts.Any(p => p.Id == id))
            {
                return NotFound();
            }
            return Ok(_productRepository.AllProducts.Where(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult SearchProduct([FromBody] string searchQuery)
        {
            IEnumerable<Product> products = new List<Product>();

            if (!string.IsNullOrEmpty(searchQuery))
            {
                products = _productRepository.SearchProduct(searchQuery);
            }

            return new JsonResult(products);
        }
    }
}
