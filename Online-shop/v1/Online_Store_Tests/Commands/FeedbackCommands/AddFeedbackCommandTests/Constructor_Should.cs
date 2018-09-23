using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Online_Store.Commands.FeedbackCommands;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Data;
using System;

namespace Online_Store_Tests.Commands.FeedbackCommands.AddFeedbackCommandTests
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
            var factory = new Mock<IModelFactory>();

            //act
            var testcommand = new AddFeedbackCommand(factory.Object, context.Object, writer.Object, reader.Object);
            
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
            var factory = new Mock<IModelFactory>();

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new AddFeedbackCommand(factory.Object, context, writer.Object, reader.Object));
        }

        [TestMethod]
        public void ThrowException_WhenIModelFactoryIsNull()
        {
            //arrange
            var context = new Mock<IStoreContext>();
            var writer = new Mock<IWriter>();
            var reader = new Mock<IReader>();
            IModelFactory factory = null;

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new AddFeedbackCommand(factory, context.Object, writer.Object, reader.Object));
        }

        [TestMethod]
        public void ThrowException_WhenIWriterIsNull()
        {
            //arrange
            var context = new Mock<IStoreContext>();
            IWriter writer = null;
            var reader = new Mock<IReader>();
            var factory = new Mock<IModelFactory>();

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new AddFeedbackCommand(factory.Object, context.Object, writer, reader.Object));
        }

        [TestMethod]
        public void ThrowException_WhenIReaderIsNull()
        {
            //arrange
            var context = new Mock<IStoreContext>();
            var writer = new Mock<IWriter>();
            IReader reader = null;
            var factory = new Mock<IModelFactory>();

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() =>
            new AddFeedbackCommand(factory.Object, context.Object, writer.Object, reader));
        }
    }
}
