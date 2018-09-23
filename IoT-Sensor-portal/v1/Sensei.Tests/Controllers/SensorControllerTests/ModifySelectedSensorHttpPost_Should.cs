using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Data.DbService;
using Sensei.Data.Models.Intermediate;
using Sensei.Database.DbContext;
using Sensei.Services;
using Sensei.Tests.Tools.CustomMockClasses;
using System.Net.Http;
using System.Web;

namespace Sensei.Tests.Controllers.SensorControllerTests
{
    [TestClass]
    public class ModifySelectedSensorHttpPost_Should
    {
        [TestMethod]
        public void ThrowHttpException_WhenUserIsntLoggedIn()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();
            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);
            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);
            
            string loggedUser = "loggedUser";

            SensorControllerMock sensorController = new SensorControllerMock(loggedUser, mockSensorDbService.Object, mockSensorApiService.Object);

            // act and assert
            Assert.ThrowsException<HttpException>(() => sensorController.ModifySelectedSensor(new SensorDisplayData
            {
                UserName = "other than logged in user"
            }));
                
        }

        [TestMethod]
        public void CallsModifySpecificSesnorInSensorDbService_WhenUserIsLoggedIn()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();
            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);
            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);

            string loggedUser = "loggedUser";

            SensorDisplayData testSensor = new SensorDisplayData
            {
                UserName = loggedUser
            };

            SensorControllerMock sensorController = new SensorControllerMock(loggedUser, mockSensorDbService.Object, mockSensorApiService.Object);

            //act
            sensorController.ModifySelectedSensor(testSensor);

            // act and assert
            mockSensorDbService.Verify(x => x.ModifySpecificSesnor(testSensor), Times.Once);
        }
    }
}