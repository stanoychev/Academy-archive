using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands.ProductCommands;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Tests.Commands.ProductCommands.RemoveProductCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ThrowException_WhenContextIsNull()
        {
            // Arange
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var productServiceMock = new Mock<IProductService>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new RemoveProductCommand(null, writerMock.Object,
                  readerMock.Object, productServiceMock.Object, userServiceMock.Object,
                  loggedUserProviderMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenWritertIsNull()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var readerMock = new Mock<IReader>();
            var productServiceMock = new Mock<IProductService>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new RemoveProductCommand(contextMock.Object,
                  null,readerMock.Object, productServiceMock.Object, userServiceMock.Object,
                  loggedUserProviderMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenReadertIsNull()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var productServiceMock = new Mock<IProductService>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new RemoveProductCommand(contextMock.Object,
                  writerMock.Object, null, productServiceMock.Object, userServiceMock.Object,
                  loggedUserProviderMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenProductServiceIsNull()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new RemoveProductCommand(contextMock.Object,
                  writerMock.Object, readerMock.Object, null, userServiceMock.Object,
                  loggedUserProviderMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenUserServiceIsNull()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var productServiceMock = new Mock<IProductService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new RemoveProductCommand(contextMock.Object,
                   writerMock.Object, readerMock.Object, productServiceMock.Object, null,
                   loggedUserProviderMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenLoggedUserProviderIsNull()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var productServiceMock = new Mock<IProductService>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new RemoveProductCommand(contextMock.Object,
                  writerMock.Object, readerMock.Object, productServiceMock.Object, userServiceMock.Object,
                  null));
        }
    }
}
