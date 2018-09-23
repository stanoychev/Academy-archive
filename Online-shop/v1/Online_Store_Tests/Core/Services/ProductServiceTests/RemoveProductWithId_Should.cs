using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Core.Factories;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Online_Store_Tests.Core.Services.ProductServiceTests
{
    [TestClass]
    public class RemoveProductWithId_Should
    {
        [TestMethod]
        public void ThrowArgumentException_WhenDatabaseDoesNotContainId()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserProviderMock.Setup(m => m.CurrentUserId).Returns(1);

            IQueryable<Product> products =
           new List<Product>
           {
                new Product { Id = 1,  ProductName = "Samsung" , Price = 200,
                    PaymentMethod = PaymentMethodEnum.Cash },
                new Product { Id = 2, ProductName = "second" , Price = 300,
                    PaymentMethod = PaymentMethodEnum.Visa},
                new Product { Id = 3, ProductName = "third" , Price = 400,
                    PaymentMethod = PaymentMethodEnum.MasterCard},
           }.AsQueryable();

            var setMockProduct = new Mock<DbSet<Product>>();
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

            contextMock.Setup(m => m.Products).Returns(setMockProduct.Object);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                   writerMock.Object, factoryMock.Object);

            string wrongId = "10";

            // Act && Assert
            Assert.ThrowsException<ArgumentException>(() => productService.RemoveProductWithId(wrongId));
        }

        [TestMethod]
        public void ReturnErrorMessage_WhenIdIsNotAnInteger()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserProviderMock.Setup(m => m.CurrentUserId).Returns(1);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                writerMock.Object, factoryMock.Object);

            string wrongIdString = "BOOM";
            string expectedResult = "ProductId Must be Int!";

            // Act
            string actualResult = productService.RemoveProductWithId(wrongIdString);

            // Assert
            Assert.AreEqual(expectedResult, actualResult);
        }

        [TestMethod]
        public void CallRemoveAndSaveChanges_WhenIdIsCorrect()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserProviderMock.Setup(m => m.CurrentUserId).Returns(1);

            IQueryable<Product> products =
                new List<Product>
                {
                     new Product { Id = 1,  ProductName = "Samsung" , Price = 200,
                         PaymentMethod = PaymentMethodEnum.Cash },
                     new Product { Id = 2, ProductName = "second" , Price = 300,
                         PaymentMethod = PaymentMethodEnum.Visa},
                     new Product { Id = 3, ProductName = "third" , Price = 400,
                         PaymentMethod = PaymentMethodEnum.MasterCard},
                }.AsQueryable();

            var setMockProduct = new Mock<DbSet<Product>>();
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

            contextMock.Setup(m => m.Products).Returns(setMockProduct.Object);

            var productMock = new Mock<Product>();
            factoryMock.Setup(m => m.CreateProduct()).Returns(productMock.Object);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                   writerMock.Object, factoryMock.Object);

            string productId = "1";

            // Act
            productService.RemoveProductWithId(productId);

            // Assert
            // contextMock.Verify(m => m.Products.Remove(It.IsAny<Product>()), Times.Once);
            contextMock.Verify(m => m.SaveChanges(), Times.Once);
        }
    }
}
