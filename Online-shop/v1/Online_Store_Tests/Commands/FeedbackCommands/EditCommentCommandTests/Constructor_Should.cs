using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands.FeedbackCommands;
using Online_Store.Core.Providers;
using Online_Store.Data;
using System;

namespace Online_Store_Tests.Commands.FeedbackCommands.EditCommentCommandTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenConstructorsArgumentsAreNotNull()
        {
            //arrange
            var context = new Mock<IStoreContext>();
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();

            //act
            var testcommand = new EditCommentCommand(context.Object, writer.Object, reader.Object);

            //assert
            Assert.IsNotNull(testcommand);
        }

        [TestMethod]
        public void ThrowException_WhenIStoreContextIsNull()
        {
            //arrange
            IStoreContext context = null;
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new EditCommentCommand(context, writer.Object, reader.Object));
        }

        [TestMethod]
        public void ThrowException_WhenIWriterIsNull()
        {
            //arrange
            var context = new Mock<IStoreContext>();
            IWriter writer = null;
            var reader = new Mock<IReader>();

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new EditCommentCommand(context.Object, writer, reader.Object));
        }

        [TestMethod]
        public void ThrowException_WhenIReaderIsNull()
        {
            //arrange
            var context = new Mock<IStoreContext>();
            var writer = new Mock<IWriter>();
            IReader reader = null;

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new EditCommentCommand(context.Object, writer.Object, reader));
        }
    }
}
