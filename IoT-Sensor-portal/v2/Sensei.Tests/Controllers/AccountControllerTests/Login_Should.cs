//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Controllers;
//using Sensei.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Mvc;

//namespace Sensei.Tests.Controllers.AccountControllerTests
//{
//    [TestClass]
//    public class Login_Should
//    {
//        [TestMethod]
//        public void LoginView_WhenInvoked()
//        {
//            // Arrange
//            new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(appDbCtx))
//            var userManager = new Mock<ApplicationUserManager>();
//            var signInManager = new Mock<ApplicationSignInManager>();
//            var controller = new AccountController(userManager.Object, signInManager.Object);

//            // Act
//            var result = controller.Login("") as ViewResult;

//            // Assert
//            Assert.IsNotNull(result);
//        }
//    }
//}
