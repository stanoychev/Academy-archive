using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Core.Factories;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Online_Store_Tests.Core.Services.ProductServiceTests
{
    [TestClass]
    public class ListProductsByCategory_Should
    {
        [TestMethod]
        public void ReturnCustomErrorMessage_WhenWrongCategoryIsEntered()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserProviderMock.Setup(m => m.CurrentUserId).Returns(1);

            IQueryable<Category> categories =
                new List<Category>
                {
                         new Category { CategoryName = "Party" },
                         new Category { CategoryName = "Piini" },
                         new Category { CategoryName = "Iadini" },
                
                }.AsQueryable();

            var setMockCategory = new Mock<DbSet<Category>>();
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => categories.GetEnumerator());

            contextMock.Setup(m => m.Categories).Returns(setMockCategory.Object);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                  writerMock.Object, factoryMock.Object);

            string wrongCategory = "Unvalid";
            string expectedResult = "No such category.";

            // Act
            string actualResult = productService.ListProductsByCategory(wrongCategory);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCorrectString_WhenEnteredCategoryExists()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserProviderMock.Setup(m => m.CurrentUserId).Returns(1);

            IQueryable<Category> categories =
                new List<Category>
                {
                    new Category
                    {
                        CategoryName = "Manja",
                        Products = new Product[]
                        {
                            new Product()
                            {
                                ProductName = "Product1",
                                Price = 20,
                                ShippingDetails = new ShippingDetails() { Cost = 20 }
                            },
                            new Product()
                            {
                                ProductName = "ProductSECOND",
                                Price = 220,
                                ShippingDetails = new ShippingDetails() { Cost = 210 }
                            }
                        }
                    },
                    new Category { CategoryName = "Piini" },
                    new Category { CategoryName = "Iadini" },

                }.AsQueryable();

            var setMockCategory = new Mock<DbSet<Category>>();
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => categories.GetEnumerator());

            contextMock.Setup(m => m.Categories).Returns(setMockCategory.Object);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                  writerMock.Object, factoryMock.Object);

            string categoryInput = "Manja";
            string expectedResult = string.Join("\n", categories
                                                        .Single(c => c.CategoryName == categoryInput).Products);

            // Act
            string actualResult =  productService.ListProductsByCategory(categoryInput);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
