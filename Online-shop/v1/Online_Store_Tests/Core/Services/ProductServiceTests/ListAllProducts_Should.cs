using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Core.Factories;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using Online_Store.Models.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Online_Store_Tests.Core.Services.ProductServiceTests.ProductServiceTests
{
    [TestClass]
    public class ListAllProducts_Should
    {
        [TestMethod]
        public void ReturnAllProductsToString_WhenThereAreProducts()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            IQueryable<Product> products =
              new List<Product>
              {
                    new Product { ProductName = "first" , Price = 200,
                        PaymentMethod = PaymentMethodEnum.Cash },
                    new Product { ProductName = "second" , Price = 300,
                        PaymentMethod = PaymentMethodEnum.Visa},
                    new Product { ProductName = "third" , Price = 400,
                        PaymentMethod = PaymentMethodEnum.MasterCard},
              }.AsQueryable();

            var setMock = new Mock<DbSet<Product>>();
            setMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            setMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            setMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            setMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

            contextMock.Setup(m => m.Products).Returns(setMock.Object);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                writerMock.Object, factoryMock.Object);

            string expectedResult = string.Join("\n", products);
            // Act
            string actualResult = productService.ListAllProducts();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void ReturnCustomErrorMessage_WhenContextContainsNoProducts()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            IQueryable<Product> products =
              new List<Product>
              {

              }.AsQueryable();

            var setMock = new Mock<DbSet<Product>>();
            setMock.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            setMock.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            setMock.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            setMock.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

            contextMock.Setup(m => m.Products).Returns(setMock.Object);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                writerMock.Object, factoryMock.Object);

            string expectedResult = "No products!";

            // Act
            string actualResult = productService.ListAllProducts();

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }
    }
}
