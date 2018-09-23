using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Tests.Core.Services.User.UserServiceTests
{
    [TestClass]
    public class CheckUsername_Should
    {
        [TestMethod]
        public void ReturnTrue_WhenContextContainsUsername()
        {
            // Arange
            IQueryable<Online_Store.Models.User> users =
                new List<Online_Store.Models.User>
                {
                    new Online_Store.Models.User { Username = "notThisOne" },
                    new Online_Store.Models.User { Username = "goshkata" },
                    new Online_Store.Models.User { Username = "pesho" },
                    new Online_Store.Models.User { Username = "sda" },
                    new Online_Store.Models.User { Username = "Testurcheto" }
                }.AsQueryable();

            var hasherMock = new Mock<IPasswordSecurityHasher>();
            var contextMock = new Mock<IStoreContext>();
            var loggedUserMock = new Mock<ILoggedUserProvider>();
            var factoryMock = new Mock<IModelFactory>();
            string username = "Testurcheto";

            // zaduljitelno trqbva da ima i 4te medota setup-nati
            var setMock = new Mock<DbSet<Online_Store.Models.User>>();
            setMock.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.Provider).Returns(users.Provider);
            setMock.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.Expression).Returns(users.Expression);
            setMock.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.ElementType).Returns(users.ElementType);
            setMock.As<IQueryable<Online_Store.Models.User>>().Setup(m => m.GetEnumerator()).Returns(() => users.GetEnumerator());

            contextMock.Setup(m => m.Users).Returns(setMock.Object);


            var userService = new UserService(hasherMock.Object, contextMock.Object, loggedUserMock.Object,
                factoryMock.Object);


            //// Act && Assert
            Assert.AreEqual(userService.CheckUsername(username), true);
        }
    }
}
