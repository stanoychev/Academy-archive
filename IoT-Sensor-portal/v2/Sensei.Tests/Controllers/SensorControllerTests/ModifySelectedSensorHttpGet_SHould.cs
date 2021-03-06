﻿//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Data.DbService;
//using Sensei.Data.Models.Intermediate;
//using Sensei.Database.DbContext;
//using Sensei.Services;
//using Sensei.Tests.Tools.CustomMockClasses;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web;
//using TestStack.FluentMVCTesting;

//namespace Sensei.Tests.Controllers.SensorControllerTests
//{
//    [TestClass]
//    public class ModifySelectedSensorHttpGet_SHould
//    {
//        [TestMethod]
//        public async Task ThrowHttpException_WhenUserIsntLoggedIn()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();
//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);
//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            string loggedUser = "owner";

//            int testSensorId = 7;

//            SensorDisplayData testModel = new SensorDisplayData
//            {
//                SensorId = testSensorId,
//                UserName = "hacker"
//            };

//            mockDBService.Setup(x => x.GetSpecificSensorDisplayDataAsync(testSensorId))
//                .Returns(Task.Run(() => testModel));

//            SensorControllerMock sensorController = new SensorControllerMock(loggedUser, mockDBService.Object, mockAPIService.Object);
            
//            // act and assert
//            await Assert.ThrowsExceptionAsync<HttpException>(() => sensorController.ModifySelectedSensor(testSensorId));
//        }

//        [TestMethod]
//        public void CallsGetSpecificSensorDisplayDataAsyncInDBService_WhenUserIsLoggedIn()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();
//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);
//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            string loggedUser = "owner";

//            int testSensorId = 7;

//            SensorDisplayData expected = new SensorDisplayData
//            {
//                SensorId = testSensorId,
//                UserName = loggedUser
//            };

//            mockDBService.Setup(x => x.GetSpecificSensorDisplayDataAsync(testSensorId))
//                .Returns(Task.Run(() => expected));

//            SensorControllerMock sensorController = new SensorControllerMock(loggedUser, mockDBService.Object, mockAPIService.Object);
            
//            // act and assert
//            sensorController.WithCallTo(c => c.ModifySelectedSensor(testSensorId))
//                .ShouldRenderPartialView("SensorPartialViews/_ModifySelectedSensor")
//                .WithModel<SensorDisplayData>(actual =>
//                {
//                    Assert.IsNotNull(actual);
//                    Assert.IsTrue(actual.SensorId == expected.SensorId);
//                    Assert.IsTrue(actual.UserName == expected.UserName);
//                });
//        }
//    }
//}
