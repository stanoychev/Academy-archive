using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Models;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace UnitTestProject1.Commands.Creating.CreateTicketCommand.Tests
{
    [TestClass]
    public class Execute_Should
    {
        [TestMethod]
        public void CreateTicketAndAddItIntoTheDatabase_WhenParametersAreCorrect()
        {
            //arrange
            List <string> testParameters = new List<string>() { "0", "20.99" };
            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            Mock<ITravellerFactory> travellerFactoryMock = new Mock<ITravellerFactory>();

            ICommand createTicketCommand = new Traveller.Commands.Creating.CreateTicketCommand(databaseMock.Object, travellerFactoryMock.Object);

            Mock<IJourney> journeyMock = new Mock<IJourney>();

            List<IJourney> listOfJourneys = new List<IJourney>() { journeyMock.Object };

            databaseMock.Setup(x => x.Journeys)
                .Returns(listOfJourneys);

            databaseMock.Setup(x => x.Tickets)
                .Returns(new List<ITicket>());

            ITicket expectedTicket = new Ticket(journeyMock.Object, decimal.Parse(testParameters[1]));

            travellerFactoryMock.Setup(x => x.CreateTicket(It.IsAny<IJourney>(), It.IsAny<decimal>()))
                .Returns(expectedTicket);
            
            //act
            createTicketCommand.Execute(testParameters);

            //assert
            Assert.AreEqual(1, databaseMock.Object.Tickets.Count);
            Assert.AreEqual(databaseMock.Object.Tickets[0],expectedTicket);
        }

        [TestMethod]
        public void ReturnTicketCreationSuccessMessage_WhenParametersAreCorrect()
        {
            //arrange
            List<string> testParameters = new List<string>() { "0", "20.99" };
            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            Mock<ITravellerFactory> travellerFactoryMock = new Mock<ITravellerFactory>();

            ICommand createTicketCommand = new Traveller.Commands.Creating.CreateTicketCommand(databaseMock.Object, travellerFactoryMock.Object);

            Mock<IJourney> journeyMock = new Mock<IJourney>();

            List<IJourney> listOfJourneys = new List<IJourney>() { journeyMock.Object };

            databaseMock.Setup(x => x.Journeys)
                .Returns(listOfJourneys);

            databaseMock.Setup(x => x.Tickets)
                .Returns(new List<ITicket>());

            ITicket expectedTicket = new Ticket(journeyMock.Object, decimal.Parse(testParameters[1]));

            travellerFactoryMock.Setup(x => x.CreateTicket(It.IsAny<IJourney>(), It.IsAny<decimal>()))
                .Returns(expectedTicket);
            
            //act
            string testOutput = createTicketCommand.Execute(testParameters);
            string expectedOutput = $"Ticket with ID {databaseMock.Object.Tickets.Count - 1} was created.";
            //Expected output must be initialized after the command execution.

            //assert
            Assert.AreEqual(expectedOutput, testOutput);
        }

        [TestMethod]
        public void ThrowException_WhenTheListWithTheParametersIsNullOrEmpty()
        {
            //arrange
            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            Mock<ITravellerFactory> travellerFactoryMock = new Mock<ITravellerFactory>();

            ICommand createTicketCommand = new Traveller.Commands.Creating.CreateTicketCommand(databaseMock.Object, travellerFactoryMock.Object);

            List<string> testParameters = null;
            
            //act and assert
            Assert.ThrowsException<ArgumentNullException>(() => createTicketCommand.Execute(testParameters));
        }

        [TestMethod]
        [DataRow("Non parsable to integer string.", "20,99")]
        [DataRow("77", "Non parsable to decimal string.")]
        [DataRow("Non parsable to integer string.", "Non parsable to decimal string.")]
        [DataRow("1", "20,99")]
        [DataRow("1", "-20.99")]
        [DataRow("1,5", "20.99")]
        [DataRow("1.5", "20.99")]
        [DataRow("-1", "20.99")]
        public void ThrowException_WhenIncomeingParametersAreNotCorrect(string journeyID, string administrativeCost)
        {
            //arrange
            List<string> testParameters = new List<string>() { journeyID, administrativeCost };

            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            Mock<ITravellerFactory> travellerFactoryMock = new Mock<ITravellerFactory>();

            databaseMock.Setup(x => x.Journeys)
                .Returns(new List<IJourney>() { It.IsAny<IJourney>(), It.IsAny<IJourney>(), It.IsAny<IJourney>(), });

            ICommand createTicketCommand = new Traveller.Commands.Creating.CreateTicketCommand(databaseMock.Object, travellerFactoryMock.Object);

            //act and assert
            Assert.ThrowsException<ArgumentException>(() => createTicketCommand.Execute(testParameters));
        }

        [TestMethod]
        [DataRow("1", "20.99")]
        [DataRow("1", "20")]
        [DataRow("1", "0")]
        public void CreatesInstance_WhenIncomeingParametersAreCorrect(string journeyID, string administrativeCost)
        {
            //arrange
            List<string> testParameters = new List<string>() { journeyID, administrativeCost };

            Mock<IDatabase> databaseMock = new Mock<IDatabase>();
            Mock<ITravellerFactory> travellerFactoryMock = new Mock<ITravellerFactory>();

            databaseMock.Setup(x => x.Journeys)
                .Returns(new List<IJourney>() { It.IsAny<IJourney>(), It.IsAny<IJourney>(), It.IsAny<IJourney>(), });

            databaseMock.Setup(x => x.Tickets)
                .Returns(new List<ITicket>());

            ICommand createTicketCommand = new Traveller.Commands.Creating.CreateTicketCommand(databaseMock.Object, travellerFactoryMock.Object);
            
            //act
            createTicketCommand.Execute(testParameters);

            //assert
            Assert.AreEqual(1, databaseMock.Object.Tickets.Count);
        }
    }
}
