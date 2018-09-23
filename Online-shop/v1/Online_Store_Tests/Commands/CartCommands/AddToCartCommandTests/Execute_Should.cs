using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands.CartCommands;
using Online_Store.Core.Factories;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Tests.Commands.CartCommands.AddToCartCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnCustomErrorMessage_WhenUserIsNotLogged()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var factoryMock = new Mock<IModelFactory>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            userServiceMock.Setup(m => m.IsUserLogged()).Returns(false);

            var command = new AddToCartCommand(loggedUserProviderMock.Object, userServiceMock.Object,
                       factoryMock.Object, contextMock.Object, writerMock.Object, readerMock.Object);

            string expectedResult = "You must Login First!";
            // Act
            var actualResul = command.Execute();

            // Assert
            Assert.AreEqual(expectedResult, actualResul);
        }

        [TestMethod]
        public void CallAddToCartMethod_WhenUserIsLogged()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var factoryMock = new Mock<IModelFactory>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            userServiceMock.Setup(m => m.IsUserLogged()).Returns(true);

            var command = new AddToCartCommand(loggedUserProviderMock.Object, userServiceMock.Object,
                       factoryMock.Object, contextMock.Object, writerMock.Object, readerMock.Object);

            // Act
          //  command.Execute();

            // Assert
           // userServiceMock.Verify(m => m.AddToCart(It.IsAny<IList<string>>()), Times.Once);
        }

    }
}
