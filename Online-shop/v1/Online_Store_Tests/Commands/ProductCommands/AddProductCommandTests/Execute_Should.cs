using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands.ProductCommands;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Tests.Commands.ProductCommands.AddProductCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnErrorMessage_WhenUserIsNotLogged()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var productServiceMock = new Mock<IProductService>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            userServiceMock.Setup(m => m.IsUserLogged()).Returns(false);

            var command = new AddProductCommand(contextMock.Object, writerMock.Object,
                       readerMock.Object, productServiceMock.Object, userServiceMock.Object,
                       loggedUserProviderMock.Object);

            string expectedResult = "You must Login First!";
            // Act
            var actualResul = command.Execute();

            // Assert
            Assert.AreEqual(expectedResult, actualResul);
        }

        [TestMethod]
        public void ReturnErrorMessage_WhenUserIsNotASeller()
        {
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var productServiceMock = new Mock<IProductService>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            IQueryable<Seller> sellers =
               new List<Seller>
               {
                   new Seller(){ UserId = 2 }
               }.AsQueryable();

            var setMock = new Mock<DbSet<Seller>>();
            setMock.As<IQueryable<Seller>>().Setup(m => m.Provider).Returns(sellers.Provider);
            setMock.As<IQueryable<Seller>>().Setup(m => m.Expression).Returns(sellers.Expression);
            setMock.As<IQueryable<Seller>>().Setup(m => m.ElementType).Returns(sellers.ElementType);
            setMock.As<IQueryable<Seller>>().Setup(m => m.GetEnumerator()).Returns(() => sellers.GetEnumerator());

            contextMock.Setup(m => m.Sellers).Returns(setMock.Object);
            loggedUserProviderMock.SetupGet(m => m.CurrentUserId).Returns(1);
            userServiceMock.Setup(m => m.IsUserLogged()).Returns(true);

            var command = new AddProductCommand(contextMock.Object, writerMock.Object,
                       readerMock.Object, productServiceMock.Object, userServiceMock.Object,
                       loggedUserProviderMock.Object);

            string expectedResult = "Can`t add products if you are not a seller.";
            // Act
            var actualResul = command.Execute();

            // Assert
            Assert.AreEqual(expectedResult, actualResul);
        }
    }
}
