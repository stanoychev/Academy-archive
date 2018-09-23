//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Controllers;
//using Sensei.Data.DbService;
//using Sensei.Database.DbContext;
//using Sensei.Services;
//using System;
//using System.Net.Http;

//namespace Sensei.Tests.Controllers.SensorControllerTests
//{
//    [TestClass]
//    public class Constructor_Should
//    {
//        [TestMethod]
//        public void ReturnInstance_WhenParameterIsCorrect()
//        {
//            // Arrange
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            // Act
//            SensorController instance = new SensorController(mockDBService.Object,
//                mockAPIService.Object);

//            // Assert
//            Assert.IsNotNull(instance);
//        }

//        [TestMethod]
//        public void ThrowArgumentNullException_WhenParametersAreNotCorrect()
//        {
//            // Arrange
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);
            
//            // Act
//            // Assert
//            Assert.ThrowsException<ArgumentNullException>(() => new SensorController(null,
//                mockAPIService.Object));
//            Assert.ThrowsException<ArgumentNullException>(() => new SensorController(mockDBService.Object,
//                null));
//        }
//    }
//}
