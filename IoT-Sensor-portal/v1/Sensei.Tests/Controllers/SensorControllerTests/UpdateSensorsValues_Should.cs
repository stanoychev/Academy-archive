using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Controllers;
using Sensei.Data.DbService;
using Sensei.Data.Models;
using Sensei.Database.DbContext;
using Sensei.Database.Models.Measurement_IO_models;
using Sensei.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Sensei.Tests.Controllers.SensorControllerTests
{
    [TestClass]
    public class UpdateSensorsValues_Should
    {
        [TestMethod]
        public void CallsListSupportedSensorTypesFromAPIInSensorApiService()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);

            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // act
            var test = sensorController.UpdateSensorsValues();

            //assert
            mockSensorApiService.Verify(x => x.ListSupportedSensorTypesFromAPI(), Times.Once);
        }

        [TestMethod]
        public void CallsGetCurrentSensorValueFromAPIInSensorApiService()
        {
            // Arrange
            // arrange controller
            Random random = new Random();
            int counter = random.Next(1, 100);

            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);

            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // arrange ListSupportedSensorTypesFromAPI in mockSensorApiService
            ICollection<string> initialCollection = new List<string>();
            for (int i = 0; i <= counter - 1; i++)
            {
                initialCollection.Add("asdasda" + i);
            }

            IEnumerable<string> expected = initialCollection;

            mockSensorApiService.Setup(x => x.ListSupportedSensorTypesFromAPI())
                .Returns(Task.Run(() => expected));

            mockSensorApiService.Setup(x => x.GetCurrentSensorValueFromAPI(It.IsAny<string>()))
                .Returns(Task.Run(() => new MeasurementReadIn()));

            // act
            var test = sensorController.UpdateSensorsValues();

            //assert
            mockSensorApiService.Verify(x => x.GetCurrentSensorValueFromAPI(It.IsAny<string>()), Times.Exactly(counter));
        }

        [TestMethod]
        public void CallsGetAllSensorsLastValuesInSsensorDbService()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);

            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // act
            var test = sensorController.UpdateSensorsValues();

            //assert
            mockSensorDbService.Verify(x => x.GetAllSensorsLastValues(), Times.Once);
        }

        [TestMethod]
        public void NotAddNewMeasurementsIntoTheDatabase_IfGetAllSensorsLastValuesFromSensorDbServiceReturnsEmptyCollection()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);

            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // arrange GetAllSensorsLastValues in mockSensorDbService
            IEnumerable<LastValueReadFromDbcs> expected = new List<LastValueReadFromDbcs>();

            mockSensorDbService.Setup(x => x.GetAllSensorsLastValues())
                .Returns(expected);

            // act
            var test = sensorController.UpdateSensorsValues();

            //assert
            mockSensorDbService.Verify(x => x.AddNewMeasurementsToDb(It.IsAny<ICollection<Measurement>>()), Times.Never);
        }

        [TestMethod]
        public void AddNewMeasurementsIntoTheDatabase_IfGetAllSensorsLastValuesFromSensorDbServiceReturnsNonEmptyCollection()
        {
            // Arrange
            // arrange controller
            Random random = new Random();
            int counter = random.Next(2, 5);

            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);

            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // arrange GetCurrentSensorValueFromAPI in mockSensorApiService
            List<LastValueReadFromDbcs> lastvalues = new List<LastValueReadFromDbcs>();
            List<string> supportedSensorTypes = new List<string>();

            for (int i = 0; i <= counter - 1; i++)
            {
                lastvalues.Add(new LastValueReadFromDbcs() { SensorIdICB = "id" + i });

                supportedSensorTypes.Add("id" + i);

                mockSensorApiService.Setup(x => x.GetCurrentSensorValueFromAPI("id" + i))
                .Returns(Task.Run(() => new MeasurementReadIn()));
            }

            mockSensorDbService.Setup(x => x.GetAllSensorsLastValues())
                .Returns(lastvalues);

            // adapt List to IEnumerable
            IEnumerable<string> adaptedSupportedSensorTypes = supportedSensorTypes;

            // arrange ListSupportedSensorTypesFromAPI in mockSensorApiService
            mockSensorApiService.Setup(x => x.ListSupportedSensorTypesFromAPI())
                .Returns(Task.Run(() => (adaptedSupportedSensorTypes)));
            
            // act
            var test = sensorController.UpdateSensorsValues();

            //assert
            mockSensorDbService.Verify(x => x.AddNewMeasurementsToDb(
                It.Is<ICollection<Measurement>>(t => t.Count == counter)), Times.Once);
        }

        [TestMethod]
        public void ReturnDefaultViewWithCorrectViewModel()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);
            
            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // act and assert
            sensorController.WithCallTo(c => c.UpdateSensorsValues())
                .ShouldRenderDefaultView();
        }
    }
}
