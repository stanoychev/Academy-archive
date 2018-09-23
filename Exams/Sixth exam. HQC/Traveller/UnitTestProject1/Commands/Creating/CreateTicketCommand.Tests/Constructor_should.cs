using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace UnitTestProject1.Commands.Creating.CreateTicketCommand.Tests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void CreateInstance_WhenConstructorsArgumentsAreNotNull()
        {
            //arrange
            var databaseMock = new Mock<IDatabase>();
            var travellerFactoryMock = new Mock<ITravellerFactory>();

            //act
            var createTicketCommand = new Traveller.Commands.Creating.CreateTicketCommand
                (databaseMock.Object, travellerFactoryMock.Object);

            //assert
            Assert.IsNotNull(createTicketCommand);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenSomeOfTheArgumentsIsNull()
        {
            //arrange
            var databaseMock = new Mock<IDatabase>();
            IDatabase nullDatabase = null;
            var travellerFactoryMock = new Mock<ITravellerFactory>();
            ITravellerFactory nullTravellerFactory = null;

            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() => new Traveller.Commands.Creating.CreateTicketCommand(nullDatabase, travellerFactoryMock.Object));
            Assert.ThrowsException<ArgumentNullException>(() => new Traveller.Commands.Creating.CreateTicketCommand(databaseMock.Object, nullTravellerFactory));
        }
    }
}
