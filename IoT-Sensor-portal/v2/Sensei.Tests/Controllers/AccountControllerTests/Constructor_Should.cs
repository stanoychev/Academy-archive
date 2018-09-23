//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Controllers;
//using Sensei.Data.DbService;
//using Sensei.Database.DbContext;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//
//namespace Sensei.Tests.Controllers.AccountControllerTests
//{
//    [TestClass]
//    public class Constructor_Should
//    {
//        [TestMethod]
//        public void ReturnInstance_WhenParametersAreCorrect()
//        {
//            // Arrange
//            var userManager = new Mock<ApplicationUserManager>();
//            var signInManager = new Mock<ApplicationSignInManager>();
//
//            // Act
//            var instance = new AccountController(userManager.Object, signInManager.Object);
//
//            // Assert
//            Assert.IsNotNull(instance);
//        }
//    }
//}
