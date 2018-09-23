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
    public class AddProduct_Should
    {
        [TestMethod]
        public void AddProductToDatabase_WhenParametersAreCorrect()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserProviderMock.Setup(m => m.CurrentUserId).Returns(1);

            List<string> parameters = new List<string>()
            {
                "Samsung", "200", "Telephone", "Cash", "20", "100", "35"
            };

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

            IQueryable<Category> categories =
            new List<Category>
            {
                    new Category { CategoryName = "Party" },
                    new Category { CategoryName = "Piini" },
                    new Category { CategoryName = "Iadini" },

            }.AsQueryable();

            var setMockProduct = new Mock<DbSet<Product>>();
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

            var setMockCategory = new Mock<DbSet<Category>>();
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.Provider).Returns(categories.Provider);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.Expression).Returns(categories.Expression);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.ElementType).Returns(categories.ElementType);
            setMockCategory.As<IQueryable<Category>>().Setup(m => m.GetEnumerator()).Returns(() => categories.GetEnumerator());

            contextMock.Setup(m => m.Products).Returns(setMockProduct.Object);
            contextMock.Setup(m => m.Categories).Returns(setMockCategory.Object);

            var productMock = new Mock<Product>();
            productMock.Setup(m => m.Categories).Returns(new HashSet<Category>());
            productMock.Setup(m => m.Feedbacks).Returns(new HashSet<Feedback>());
            productMock.Setup(m => m.Carts).Returns(new HashSet<Cart>());

            factoryMock.Setup(m => m.CreateProduct()).Returns(productMock.Object);

            var categoryMock = new Mock<Category>();
            factoryMock.Setup(m => m.CreateCategory()).Returns(categoryMock.Object);

            var shippingMock = new Mock<ShippingDetails>();
            factoryMock.Setup(m => m.CreateShippingDetails()).Returns(shippingMock.Object);

            var saleMock = new Mock<Sale>();
            factoryMock.Setup(m => m.CreateSale()).Returns(saleMock.Object);

            var legitProduct = new Product()
            {
                ProductName = "Samsung",
                Price = 200,
                Categories = new Category[] { new Category("Telephone") },
                PaymentMethod = PaymentMethodEnum.Cash,
                Instock = true,
                ShippingDetails = new ShippingDetails(20, 100),
                Sale = new Sale(35)
            };
            //var result = new Mock<Product>();
            //result.Object.ProductName = "Samsung";
            //result.Object.Price = 200;
            //result.Object.Categories = new Category[] { new Category("Telephone") };
            //result.Object.PaymentMethod = PaymentMethodEnum.Cash;
            //result.Object.ShippingDetails = new ShippingDetails(20, 100);
            //result.Object.Sale = new Sale(35);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                     writerMock.Object, factoryMock.Object);

            // Act
            productService.AddProduct(parameters);

            // Assert
            // Assert.AreEqual(contextMock.Object.Products.Last(), legitProduct);
            setMockProduct.Verify(m => m.Add(It.IsAny<Product>()), Times.Once);
            contextMock.Verify(m => m.SaveChanges(), Times.Once);
        }

        [TestMethod]
        public void ReturnErrorMessage_WhenPriceIsNegative()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();
            var writerMock = new Mock<IWriter>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserProviderMock.Setup(m => m.CurrentUserId).Returns(1);

            List<string> parameters = new List<string>()
            {
                "Samsung", "-1000", "Telephone", "Cash", "20", "100", "35"
            };

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

            var setMockProduct = new Mock<DbSet<Product>>();
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

            contextMock.Setup(m => m.Products).Returns(setMockProduct.Object);

            var productService = new ProductService(contextMock.Object, loggedUserProviderMock.Object,
                              writerMock.Object, factoryMock.Object);

            string expectedResult = "One or more parameters for the AddProduct command are invalid.";

            // Act 
            string actualResult = productService.AddProduct(parameters);
            // Assert

            Assert.AreEqual(actualResult, expectedResult);
        }
    }
}
