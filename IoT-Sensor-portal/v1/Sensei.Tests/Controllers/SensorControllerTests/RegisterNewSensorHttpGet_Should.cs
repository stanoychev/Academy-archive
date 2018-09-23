using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Controllers;
using Sensei.Data.DbService;
using Sensei.Data.Models.Intermediate;
using Sensei.Data.Models.Intermediate.Wrappers;
using Sensei.Database.DbContext;
using Sensei.Services;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TestStack.FluentMVCTesting;

namespace Sensei.Tests.Controllers.SensorControllerTests
{
    [TestClass]
    public class RegisterNewSensorHttpGet_Should
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

            // arrange availableSensorsFromAPI

            SensorReadInData sensorReadInData1 = new SensorReadInData();
            SensorReadInData sensorReadInData2 = new SensorReadInData();

            IDictionary<string, SensorReadInData> expected = new Dictionary<string, SensorReadInData>();
            expected.Add("key1", sensorReadInData1);
            expected.Add("key2", sensorReadInData2);

            // arrange sensorApiService
            mockSensorApiService.Setup(x => x.ListSensorsFromAPI())
                .Returns(Task.Run(() => expected));

            // arrange viewModel
            RegisterNewSensorViewModel registerNewSensorViewModel = new RegisterNewSensorViewModel
            {
                AvailableSensors = expected.Values
            };
            
            // arrange actual controller
            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // act and assert
            sensorController.WithCallTo(c => c.RegisterNewSensor())
                .ShouldRenderDefaultView()
                .WithModel<RegisterNewSensorViewModel> (actual =>
                {
                    Assert.IsNotNull(actual.AvailableSensors);
                    CollectionAssert.AreEquivalent(registerNewSensorViewModel.AvailableSensors.ToList(),
                        actual.AvailableSensors.ToList());
                });
        }

        [TestMethod]
        public async Task UpdateSensorTypesInSensorDbService()
        {
            // Arrange
            // arrange controller
            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

            Mock<SensorDbService> mockSensorDbService = new Mock<SensorDbService>(mockApplicationDbContext.Object);

            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
            Mock<SensorApiService> mockSensorApiService = new Mock<SensorApiService>(mockHttpClient.Object);
            
            // arrange availableSensorsFromAPI

            SensorReadInData sensorReadInData1 = new SensorReadInData
            {
                SensorId = "SensorId",
                Tag = "Tag",
                Description = "Description",
                MinPollingIntervalInSeconds = 3453,
                MeasureType = "MeasureType"
            };

            SensorReadInData sensorReadInData2 = new SensorReadInData
            {
                SensorId = "SensorIdSensorId",
                Tag = "TagTag",
                Description = "DescriptionDescription",
                MinPollingIntervalInSeconds = 3453,
                MeasureType = "MeasureTypeMeasureType"
            };

            IDictionary<string, SensorReadInData> expected = new Dictionary<string, SensorReadInData>();
            expected.Add(sensorReadInData1.SensorId, sensorReadInData1);
            expected.Add(sensorReadInData2.SensorId, sensorReadInData2);

            // arrange sensorApiService
            mockSensorApiService.Setup(x => x.ListSensorsFromAPI())
                .Returns(Task.Run(() => expected));
            
            // arrange actual controller
            SensorController sensorController = new SensorController(mockSensorDbService.Object, mockSensorApiService.Object);

            // act and assert
            await sensorController.RegisterNewSensor();
            mockSensorDbService.Verify(x => x.UpdateSensorTypes(expected), Times.Once());
        }
    }
}