﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
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

namespace Online_Store_Tests.Commands.ListProductsOnSaleCommandTests
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
            var userServiceMock = new Mock<IUserService>();

            userServiceMock.Setup(m => m.IsUserLogged()).Returns(false);

            var command = new ListProductsOnSaleCommand(contextMock.Object, writerMock.Object,
                       readerMock.Object);

            string expectedResult = "You must Login First!";
            // Act
            var actualResul = command.Execute();

            // Assert
            Assert.AreEqual(expectedResult, actualResul);
        }
    }
}
