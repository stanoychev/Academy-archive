using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using Online_Store.Models.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Online_Store_Tests.Core.Services.UserTests.UserServiceTests
{
    [TestClass]
    public class AddToCart_Should
    {
        [TestMethod]
        public void CallAddMethodOnCartProducts_WhenParametersAreCorrect()
        {
            // Arange
            var hasherMock = new Mock<IPasswordSecurityHasher>();
            var contextMock = new Mock<IStoreContext>();
            var loggedUserMock = new Mock<ILoggedUserProvider>();
            var factoryMock = new Mock<IModelFactory>();

            loggedUserMock.Setup(m => m.CurrentUserId).Returns(1);

            Cart cart = new Cart();
            cart.Products = new HashSet<Product>();

            IQueryable<Online_Store.Models.User> users =
               new List<Online_Store.Models.User>
               {
                    new Online_Store.Models.User { Id = 1, Username = "goshkata" , Cart = cart },
                    new Online_Store.Models.User { Id = 2, Username = "notThisOne" },
                    new Online_Store.Models.User { Id = 3, Username = "pesho" },
                    new Online_Store.Models.User { Id = 4, Username = "sda" },
                    new Online_Store.Models.User { Id = 5, Username = "Testurcheto" }
               }.AsQueryable();

            IQueryable<Product> products =
             new List<Product>
             {
                    new Product { Id = 1, ProductName = "first" , Price = 200,
                        PaymentMethod = PaymentMethodEnum.Cash },
                    new Product { Id = 2, ProductName = "second" , Price = 300,
                        PaymentMethod = PaymentMethodEnum.Visa},
                    new Product { Id = 3, ProductName = "third" , Price = 400,
                        PaymentMethod = PaymentMethodEnum.MasterCard},
             }.AsQueryable();

            var setMockUsers = new Mock<DbSet<Online_Store.Models.User>>();
            setMockUsers.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMockUsers.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMockUsers.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMockUsers.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            var setMockProduct = new Mock<DbSet<Product>>();
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Provider).Returns(products.Provider);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.Expression).Returns(products.Expression);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.ElementType).Returns(products.ElementType);
            setMockProduct.As<IQueryable<Product>>().Setup(m => m.GetEnumerator()).Returns(() => products.GetEnumerator());

            contextMock.Setup(m => m.Users).Returns(setMockUsers.Object);
            contextMock.Setup(m => m.Products).Returns(setMockProduct.Object);

            var productMock = new Mock<Product>();
            factoryMock.Setup(m => m.CreateProduct()).Returns(productMock.Object);

            var userService = new UserService(hasherMock.Object, contextMock.Object, loggedUserMock.Object,
               factoryMock.Object);

            IList<string> parameters = new List<string>() { "1", "null" };

            // Act
            userService.AddToCart(parameters);

            // Assert
             contextMock.Verify(m => m.Users.Single(u => u.Id == 1).Cart.Products.Add(It.IsAny<Product>()), Times.Once);
        }
    }
}
