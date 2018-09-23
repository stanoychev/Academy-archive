using System;
using System.Text;
using System.Collections.Generic;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sensei.Controllers;

namespace Sensei.Tests.Controllers.ErrorControllerTests
{
    [TestClass]
    public class Default_Should
    {
        [TestMethod]
        public void ReturnView_WhenCalled()
        {
            // Arrange
            var controller = new ErrorController();

            // Act
            var result = controller.Default() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
