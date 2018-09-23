//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Controllers;
//using Sensei.Data.DbService;
//using Sensei.Data.Models;
//using Sensei.Database.DbContext;
//using Sensei.Database.Models.Measurement_IO_models;
//using Sensei.Services;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Threading.Tasks;
//using TestStack.FluentMVCTesting;

//namespace Sensei.Tests.Controllers.SensorControllerTests
//{
//    [TestClass]
//    public class UpdateSensorsValues_Should
//    {
//        [TestMethod]
//        public void CallsListSupportedSensorTypesFromAPIInAPIService()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // act
//            var test = sensorController.UpdateSensorsValues();

//            //assert
//            mockAPIService.Verify(x => x.ListSupportedSensorTypesFromAPI(), Times.Once);
//        }

//        [TestMethod]
//        public void CallsGetCurrentSensorValueFromAPIInAPIService()
//        {
//            // Arrange
//            // arrange controller
//            Random random = new Random();
//            int counter = random.Next(1, 100);

//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // arrange ListSupportedSensorTypesFromAPI in mockAPIService
//            ICollection<string> initialCollection = new List<string>();
//            for (int i = 0; i <= counter - 1; i++)
//            {
//                initialCollection.Add("asdasda" + i);
//            }

//            IEnumerable<string> expected = initialCollection;

//            mockAPIService.Setup(x => x.ListSupportedSensorTypesFromAPI())
//                .Returns(Task.Run(() => expected));

//            mockAPIService.Setup(x => x.GetCurrentSensorValueFromAPI(It.IsAny<string>()))
//                .Returns(Task.Run(() => new APIMeasure()));

//            // act
//            var test = sensorController.UpdateSensorsValues();

//            //assert
//            mockAPIService.Verify(x => x.GetCurrentSensorValueFromAPI(It.IsAny<string>()), Times.Exactly(counter));
//        }

//        [TestMethod]
//        public void CallsGetAllSensorsLastValuesInSDBService()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // act
//            var test = sensorController.UpdateSensorsValues();

//            //assert
//            mockDBService.Verify(x => x.GetAllSensorsLastValues(), Times.Once);
//        }

//        [TestMethod]
//        public void NotAddNewMeasurementsIntoTheDatabase_IfGetAllSensorsLastValuesFromDBServiceReturnsEmptyCollection()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // arrange GetAllSensorsLastValues in mockDBService
//            IEnumerable<LastValueReadFromDbcs> expected = new List<LastValueReadFromDbcs>();

//            mockDBService.Setup(x => x.GetAllSensorsLastValues())
//                .Returns(expected);

//            // act
//            var test = sensorController.UpdateSensorsValues();

//            //assert
//            mockDBService.Verify(x => x.AddNewMeasurementsToDb(It.IsAny<ICollection<Measurement>>()), Times.Never);
//        }

//        [TestMethod]
//        public void AddNewMeasurementsIntoTheDatabase_IfGetAllSensorsLastValuesFromDBServiceReturnsNonEmptyCollection()
//        {
//            // Arrange
//            // arrange controller
//            Random random = new Random();
//            int counter = random.Next(2, 5);

//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // arrange GetCurrentSensorValueFromAPI in mockAPIService
//            List<LastValueReadFromDbcs> lastvalues = new List<LastValueReadFromDbcs>();
//            List<string> supportedSensorTypes = new List<string>();

//            for (int i = 0; i <= counter - 1; i++)
//            {
//                lastvalues.Add(new LastValueReadFromDbcs() { SensorIdICB = "id" + i });

//                supportedSensorTypes.Add("id" + i);

//                mockAPIService.Setup(x => x.GetCurrentSensorValueFromAPI("id" + i))
//                .Returns(Task.Run(() => new APIMeasure()));
//            }

//            mockDBService.Setup(x => x.GetAllSensorsLastValues())
//                .Returns(lastvalues);

//            // adapt List to IEnumerable
//            IEnumerable<string> adaptedSupportedSensorTypes = supportedSensorTypes;

//            // arrange ListSupportedSensorTypesFromAPI in mockAPIService
//            mockAPIService.Setup(x => x.ListSupportedSensorTypesFromAPI())
//                .Returns(Task.Run(() => (adaptedSupportedSensorTypes)));
            
//            // act
//            var test = sensorController.UpdateSensorsValues();

//            //assert
//            mockDBService.Verify(x => x.AddNewMeasurementsToDb(
//                It.Is<ICollection<Measurement>>(t => t.Count == counter)), Times.Once);
//        }

//        [TestMethod]
//        public void ReturnDefaultViewWithCorrectViewModel()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);
            
//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // act and assert
//            sensorController.WithCallTo(c => c.UpdateSensorsValues())
//                .ShouldRenderDefaultView();
//        }
//    }
//}
