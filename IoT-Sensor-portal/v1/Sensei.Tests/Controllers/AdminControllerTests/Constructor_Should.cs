//using System;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Contracts.DatabaseContexts;
//using Sensei.Controllers;
//using Sensei.Database.DbContext;
//using Sensei.Models;

//namespace Sensei.Tests.Controllers.AdminControllerTests
//{
//    [TestClass]
//    public class Constructor_Should
//    {
//        [TestMethod]
//        public void ReturnInstance_WhenParametersAreCorrect()
//        {
//            // Arrange
//            var userManager = new Mock<ApplicationUserManager>();
//            var appDbCtx = ApplicationDbContext.Create();

//            // Act
//            var instance = new AdminController(userManager.Object, appDbCtx);

//            // Assert
//            Assert.IsNotNull(instance);
//        }
//    }
//}
