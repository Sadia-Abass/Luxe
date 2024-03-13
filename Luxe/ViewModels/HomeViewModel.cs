using Luxe.Models;

namespace Luxe.ViewModels
{
  
    public class HomeViewModel
    {
        public IEnumerable<Product> PopularProduct { get; }

        public HomeViewModel(IEnumerable<Product> popularProduct)
        {
            PopularProduct = popularProduct;
        }
    }
}
