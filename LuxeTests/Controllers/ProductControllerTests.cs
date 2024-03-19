using Luxe.Controllers;
using Luxe.ViewModels;
using LuxeTests.Mocks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace LuxeTests.Controllers
{
    public class ProductControllerTests
    {
        [Fact]
        public void List_EmptyCategory_ReturnsAllProducts()
        {
            // Arrange
            var mockCategoryRepository = RepositoryMocks.GetCategoryRepository();
            var mockProductRepository = RepositoryMocks.GetProductRepository();

            var productController = new ProductController(mockProductRepository.Object, mockCategoryRepository.Object);

            // Act
            var result = productController.List("");

            // Assert
            var viewResult = Assert.IsType<ViewResult>(result);
            var productListViewModel = Assert.IsAssignableFrom<ProductListViewModel>(viewResult.ViewData.Model);
            Assert.Equal(3, productListViewModel.Products.Count());
        }
    }
}
