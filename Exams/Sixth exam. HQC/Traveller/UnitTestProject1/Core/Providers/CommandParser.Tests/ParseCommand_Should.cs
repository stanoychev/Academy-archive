using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Factories;

namespace UnitTestProject1.Core.Providers.CommandParser.Tests
{
    [TestClass]
    public class ParseCommand_Should
    {
        [TestMethod]
        public void ReturnsCommand_WhenParametersAreCorrect()
        {
            //arrange
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            string testCommand = "testCommand";
            IParser testParser = new Traveller.Core.Providers.CommandParser();

            Mock<ICommand> expectedCommand = new Mock<ICommand>();

            commandFactoryMock.Setup(x => x.CreateCommand(testCommand))
                .Returns(expectedCommand.Object);

            //act
            ICommand testCommandObject = testParser.ParseCommand(testCommand, commandFactoryMock.Object);

            //assert
            Assert.AreEqual(expectedCommand.Object, testCommandObject);
        }

        [TestMethod]
        public void ThrowsException_WhenOneOFTheParametersIsNull()
        {
            //arrange
            Mock<ICommandFactory> commandFactoryMock = new Mock<ICommandFactory>();
            ICommandFactory nullCommandFactory = null;
            string testCommand = "testCommand";
            string nullTestCommand = null;
            string emptyTestCommand = "";

            IParser testParser = new Traveller.Core.Providers.CommandParser();
            
            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() => testParser.ParseCommand(nullTestCommand, commandFactoryMock.Object));
            Assert.ThrowsException<ArgumentException>(() => testParser.ParseCommand(emptyTestCommand, commandFactoryMock.Object));
            Assert.ThrowsException<ArgumentNullException>(() => testParser.ParseCommand(testCommand, nullCommandFactory));
        }
    }
}
