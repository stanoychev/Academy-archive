using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands.ProductCommands;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;

namespace Online_Store_Tests.Commands.ProductCommands.ListProductsByCategoryCommandTests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void ReturnCustomMessage_WhenUserIsNotLogged()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();
            var readerMock = new Mock<IReader>();
            var productServiceMock = new Mock<IProductService>();
            var userServiceMock = new Mock<IUserService>();
            var loggedUserProviderMock = new Mock<ILoggedUserProvider>();

            userServiceMock.Setup(m => m.IsUserLogged()).Returns(false);

            var command = new ListProductsByCategoryCommand(contextMock.Object, writerMock.Object,
                       readerMock.Object, productServiceMock.Object, userServiceMock.Object,
                       loggedUserProviderMock.Object);

            string expectedResult = "You must Login First!";
            // Act
            var actualResul = command.Execute();

            // Assert
            Assert.AreEqual(expectedResult, actualResul);
        }
    
    }
}
