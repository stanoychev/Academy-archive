using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Controllers;
using Sensei.Data.DbService;
using Sensei.Database.DbContext;
using Sensei.Services;
using System;
using System.Net.Http;

namespace Sensei.Tests.Controllers.SensorControllerTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParameterIsCorrect()
        {
            // Arrange
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);

            // Act
            SensorController instance = new SensorController(mockSensorDbService.Object,
                mockSensorApiService.Object);

            // Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParametersAreNotCorrect()
        {
            // Arrange
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);
            
            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SensorController(null,
                mockSensorApiService.Object));
            Assert.ThrowsException<ArgumentNullException>(() => new SensorController(mockSensorDbService.Object,
                null));
        }
    }
}
