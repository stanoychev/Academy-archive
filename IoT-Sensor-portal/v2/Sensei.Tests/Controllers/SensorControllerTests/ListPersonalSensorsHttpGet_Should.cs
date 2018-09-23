//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Data.DbService;
//using Sensei.Data.Models.Intermediate;
//using Sensei.Data.Models.Intermediate.Wrappers;
//using Sensei.Database.DbContext;
//using Sensei.Services;
//using Sensei.Tests.Tools.CustomMockClasses;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using TestStack.FluentMVCTesting;

//namespace Sensei.Tests.Controllers.SensorControllerTests
//{
//    [TestClass]
//    public class ListPersonalSensorsHttpGet_Should
//    {
//        [TestMethod]
//        public void ReturnDefaultViewWithCorrectViewModel()
//        {
//            // Arrange

//            //arrange username
//            string loggeduser = "loggeduser";

//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);
            
//            // arrange availableSensorsFromAPI
//            SensorDisplayData sensorDisplayData1 = new SensorDisplayData();
//            SensorDisplayData sensorDisplayData2 = new SensorDisplayData();

//            List<SensorDisplayData> expected = new List<SensorDisplayData>();
//            expected.Add(sensorDisplayData1);
//            expected.Add(sensorDisplayData2);
            
//            // arrange mockDBService
//            mockDBService.Setup(x => x.ListOwnSensors(loggeduser))
//                .Returns(expected);
            
//            // arrange actual controller
//            SensorControllerMock sensorController = new SensorControllerMock(loggeduser, mockDBService.Object, mockAPIService.Object);
            
//            // act and assert
//            sensorController.WithCallTo(c => c.ListPersonalSensors())
//                .ShouldRenderDefaultView()
//                .WithModel<IEnumerable<SensorDisplayData>>(actual =>
//                {
//                    Assert.IsNotNull(actual);
//                    CollectionAssert.AreEquivalent(expected, actual.ToList());
//                });
//        }
//    }
//}