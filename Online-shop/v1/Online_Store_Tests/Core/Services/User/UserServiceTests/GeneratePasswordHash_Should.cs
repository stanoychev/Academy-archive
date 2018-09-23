using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services;
using Online_Store.Core.Services.User;
using Online_Store.Data;

namespace Online_Store_Tests.Core.Services.User.UserServiceTests
{
    [TestClass]
    public class GeneratePasswordHash_Should
    {
        [TestMethod]
        public void CallHashMethod_WhenCalled()
        {
            //Arange
            var hasherMock = new Mock<IPasswordSecurityHasher>();
            var contextMock = new Mock<IStoreContext>();
            var loggedUserMock = new Mock<ILoggedUserProvider>();
            var factoryMock = new Mock<IModelFactory>();

            string password = "test";

            var userService = new UserService(hasherMock.Object, contextMock.Object, loggedUserMock.Object,
                factoryMock.Object);

            ////Act
            userService.GeneratePasswordHash(password);

             
            //Assert
            hasherMock.Verify(x => x.Hash(password), Times.Once);
        }
    }
}
