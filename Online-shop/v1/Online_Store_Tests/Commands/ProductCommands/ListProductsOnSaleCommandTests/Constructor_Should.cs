using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands.ProductCommands;
using Online_Store.Core.Providers;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online_Store_Tests.Commands.ProductCommands.ListProductsOnSaleCommandTests
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

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListProductsOnSaleCommand(null,
                  writerMock.Object,
                  readerMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenWritertIsNull()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var readerMock = new Mock<IReader>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListProductsOnSaleCommand(contextMock.Object,
                  null,
                  readerMock.Object));
        }

        [TestMethod]
        public void ThrowException_WhenReadertIsNull()
        {
            // Arange
            var contextMock = new Mock<IStoreContext>();
            var writerMock = new Mock<IWriter>();

            // Act && Assert
            Assert.ThrowsException<ArgumentNullException>(() => new ListProductsOnSaleCommand(contextMock.Object,
                 writerMock.Object,
                 null));
        }
    }
}
