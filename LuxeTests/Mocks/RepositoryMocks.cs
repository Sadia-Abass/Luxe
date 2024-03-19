using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Luxe.Models;
using Luxe.Repositories;
using Moq;

namespace LuxeTests.Mocks
{
    public class RepositoryMocks
    {
        public static Mock<IProductRepository> GetProductRepository()
        {
            var products = new List<Product>
            {
                new Product
                {
                    Name = "Dr Organic Manuka Honey Body Wash 250ml",
                    Price = 6.49M,
                    ShortDescription = "Gently refreshing body wash",
                    LongDescription = "for naturally restored skin",
                    Category = Categories["Toiletries"],
                    ImageUrl = @"~\Images\Products\DrOrganic.jpeg",
                    InStock = true,
                    ImageThumbnailUrl = @"~\Images\Products\DrOrganic.jpeg",
                },

                new Product
                {
                    Name = "L'Oreal Paris True Match Face Blush 120 Sandalwood Pink 5g",
                    Price = 8.99M,
                    ShortDescription = "Discover True Match Blush for a soft, healthy-looking glow.",
                    LongDescription = "True Match Blush comes in pink, apricot and honey hues to match every woman's skin tone warm, cool or neutral.",
                    Category = Categories["Make Up"],
                    ImageUrl = @"~\Images\Products\LorealBlush.jpeg",
                    InStock = true,
                    ImageThumbnailUrl = @"~\Images\Products\LorealBlush.jpeg"
                },

                new Product
                {
                    Name = "Dr Organic Manuka Honey Body Butter 200g",
                    Price = 9.99M,
                    ShortDescription = "The unique properties of Manuka honey have been captured in this restoring body",
                    LongDescription = "butter infused with a blend of natural ingredients such as Aloe Vera and Shea Butter.",
                    Category = Categories["Skin Care"],
                    ImageUrl = @"~\Images\Products\BodyButterDrOrganic.jpeg",
                    InStock= true,
                    ImageThumbnailUrl = @"~\Images\Products\BodyButterDrOrganic.jpeg"
                }
            };

            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(repo => repo.AllProducts).Returns(products);
            mockProductRepository.Setup(repo => repo.GetProductById(It.IsAny<int>())).Returns(products[0]);

            return mockProductRepository;
        }

        public static Mock<ICategoryRepository> GetCategoryRepository()
        {
            var categories = new List<Category>
            {
                new Category
                {
                    Id = 1,
                    Name = "Skin Care",
                    Description = "The use of cosmetics to care for the skin."
                },

                new Category 
                { 
                    Id = 2, 
                    Name = "Make Up",
                    Description = "A type of cosmetics (such as lipstick, mascara, and eye shadow) used to color and beautify the face."
                },

                new Category 
                { 
                    Id = 3, 
                    Name = "Toiletries", 
                    Description = " Are objects and substances that you use in washing yourself and preventing the body from smelling unpleasant"
                }
            };

            var mockCategoryRepository = new Mock<ICategoryRepository>();
            mockCategoryRepository.Setup(repo => repo.AllCategories).Returns(categories);

            return mockCategoryRepository;  
        }

        private static Dictionary<string, Category>? _categories;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if(_categories == null)
                {
                    var genreList = new Category[]
                    {
                        new Category { Name = "Skin Care" },
                        new Category { Name = "Make Up" },
                        new Category { Name = "Toiletries" }
                    };

                    _categories = new Dictionary<string, Category>();

                    foreach(var genre in genreList)
                    {
                        _categories.Add(genre.Name, genre);
                    }
                }

                return _categories;
            }
        }
    }
}
