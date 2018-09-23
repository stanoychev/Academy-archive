using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Controllers;
using Sensei.Data.DbService;
using Sensei.Data.Models.Intermediate;
using Sensei.Database.DbContext;
using Sensei.Services;
using System.Collections.Generic;
using System.Net.Http;
using TestStack.FluentMVCTesting;

namespace Sensei.Tests.Controllers.SensorControllerTests
{
    [TestClass]
    public class ListAllPublicSensors_Should
    {
        [TestMethod]
        public void ReturnDefaultViewWithCorrectViewModel()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);
            
            // arrange publicSensors
            SensorDisplayData sensorDisplayData1 = new SensorDisplayData();            
            SensorDisplayData sensorDisplayData2 = new SensorDisplayData();

            List<SensorDisplayData> expected = new List<SensorDisplayData>();
            expected.Add(sensorDisplayData1);
            expected.Add(sensorDisplayData2);
            
            // arrange mockSensorDbService
            mockSensorDbService.Setup(x => x.ListPublicSensorsFromDB())
                .Returns(expected);
            
            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // act and assert
            sensorController.WithCallTo(c => c.ListAllPublicSensors())
                .ShouldRenderDefaultView()
                .WithModel<List<SensorDisplayData>>(actual =>
                {
                    Assert.IsNotNull(actual);
                    CollectionAssert.AreEquivalent(expected, actual);
                });
        }
    }
}
