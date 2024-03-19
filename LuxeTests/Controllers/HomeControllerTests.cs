using Luxe.Controllers;
using Luxe.ViewModels;
using LuxeTests.Mocks;
using System.Linq;
using Xunit;



namespace LuxeTests.Controllers
{
    public class HomeControllerTests
    {
        [Fact]
        public void Index_Use_PopularProducts_FromRepository()
        {
            var mockProductRepository = RepositoryMocks.GetProductRepository();

            HomeController homeController = new HomeController(mockProductRepository.Object);   

            var result = homeController.Index().ViewData.Model as HomeViewModel;

            Assert.NotNull(result);

            var popularProduct = result?.PopularProduct?.ToList();
            Assert.NotNull(popularProduct);
            Assert.True(popularProduct.Count == 3);
            Assert.Equal("Dr Organic Manuka Honey Body Wash 250ml", popularProduct?[0].Name);
        }
    }
}
