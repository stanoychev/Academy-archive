//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Controllers;
//using Sensei.Data.DbService;
//using Sensei.Data.Models.Intermediate;
//using Sensei.Data.Models.Intermediate.Wrappers;
//using Sensei.Database.DbContext;
//using Sensei.Services;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Threading.Tasks;
//using TestStack.FluentMVCTesting;

//namespace Sensei.Tests.Controllers.SensorControllerTests
//{
//    [TestClass]
//    public class RegisterNewSensorHttpGet_Should
//    {
//        [TestMethod]
//        public void ReturnDefaultViewWithCorrectViewModel()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            // arrange availableSensorsFromAPI

//            APISensorType APISensorType1 = new APISensorType();
//            APISensorType APISensorType2 = new APISensorType();

//            IDictionary<string, APISensorType> expected = new Dictionary<string, APISensorType>();
//            expected.Add("key1", APISensorType1);
//            expected.Add("key2", APISensorType2);

//            // arrange APIService
//            mockAPIService.Setup(x => x.ListSensorsFromAPI())
//                .Returns(Task.Run(() => expected));

//            // arrange viewModel
//            RegisterNewSensorViewModel registerNewSensorViewModel = new RegisterNewSensorViewModel
//            {
//                AvailableSensors = expected.Values
//            };
            
//            // arrange actual controller
//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // act and assert
//            sensorController.WithCallTo(c => c.RegisterNewSensor())
//                .ShouldRenderDefaultView()
//                .WithModel<RegisterNewSensorViewModel> (actual =>
//                {
//                    Assert.IsNotNull(actual.AvailableSensors);
//                    CollectionAssert.AreEquivalent(registerNewSensorViewModel.AvailableSensors.ToList(),
//                        actual.AvailableSensors.ToList());
//                });
//        }

//        [TestMethod]
//        public async Task UpdateSensorTypesInDBService()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);
            
//            // arrange availableSensorsFromAPI

//            APISensorType APISensorType1 = new APISensorType
//            {
//                SensorId = "SensorId",
//                Tag = "Tag",
//                Description = "Description",
//                MinPollingIntervalInSeconds = 3453,
//                MeasureType = "MeasureType"
//            };

//            APISensorType APISensorType2 = new APISensorType
//            {
//                SensorId = "SensorIdSensorId",
//                Tag = "TagTag",
//                Description = "DescriptionDescription",
//                MinPollingIntervalInSeconds = 3453,
//                MeasureType = "MeasureTypeMeasureType"
//            };

//            IDictionary<string, APISensorType> expected = new Dictionary<string, APISensorType>();
//            expected.Add(APISensorType1.SensorId, APISensorType1);
//            expected.Add(APISensorType2.SensorId, APISensorType2);

//            // arrange APIService
//            mockAPIService.Setup(x => x.ListSensorsFromAPI())
//                .Returns(Task.Run(() => expected));
            
//            // arrange actual controller
//            SensorController sensorController = new SensorController(mockDBService.Object, mockAPIService.Object);

//            // act and assert
//            await sensorController.RegisterNewSensor();
//            mockDBService.Verify(x => x.UpdateSensorTypes(expected), Times.Once());
//        }
//    }
//}