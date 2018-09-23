//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Data.DbService;
//using Sensei.Data.Models;
//using Sensei.Data.Models.Intermediate;
//using Sensei.Data.Models.Intermediate.Wrappers;
//using Sensei.Database.DbContext;
//using Sensei.Database.Models;
//using Sensei.Models;
//using Sensei.Services;
//using Sensei.Tests.Tools.CustomMockClasses;
//using System;
//using System.Collections.Generic;
//using System.Net.Http;
//using System.Threading.Tasks;
//using TestStack.FluentMVCTesting;

//namespace Sensei.Tests.Controllers.SensorControllerTests
//{
//    [TestClass]
//    public class RegisterNewSensorHttpPost_Should
//    {
//        [TestMethod]
//        public async Task RegisterNewSensor_WhenParametersAreCorrect()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            //arrange RegisterNewSensorViewModel
//            DateTime testDateTime1 = DateTime.Now;
//            Sensor testSensor = new Sensor
//            {
//                SensorId = 8,
//                Name = "dsadas",
//                DescriptionGivenByTheUser = "asdas",
//                MeasurementType = "C",
//                IsPublic = true,
//                OperatingRange = "This sensor will return values between 6 and 18",
//                MinValue = 13.4,
//                MaxValue = 14.4,
//                AddedOn = testDateTime1,
//                Measurements = new HashSet<Measurement>(),
//                SharedWith = new HashSet<ApplicationUser>()
//            };

//            DateTime testDateTime2 = DateTime.Now;
//            LastValue testLastValue = new LastValue
//            {
//                SensorId = 45,
//                Sensor = testSensor,
//                SensorIdICB = "SensorIdICB",
//                PollingInterval = 453,
//                Value = "Value",
//                LastUpdatedOn = testDateTime2
//            };

//            testSensor.LastValue = testLastValue;

//            RegisterNewSensorViewModel expected = new RegisterNewSensorViewModel
//            {
//                Sensor = testSensor
//            };

//            //koleto. Zaradi validaciite
//            SensorType sensorType = new SensorType
//            {
//                Id = 342,
//                SensorIdICB = "SensorIdICB",
//                IsNumericValue = true,
//                MeasureType = "C",
//                MinPollingIntervalInSeconds = 0,
//                Tag = "Tag"
//            };

//            mockDBService.Setup(x => x.GetSpecificSensorType("SensorIdICB"))
//                .Returns(sensorType);

//            IDictionary<string, APISensorType> mockSensorsFromAPI = new Dictionary<string, APISensorType>();

//            mockSensorsFromAPI.Add("SensorIdICB", new APISensorType()
//            {
//                Tag = "Tag",
//                MinPollingIntervalInSeconds = 0,
//                MeasureType = "C",
//                Description = "This sensor will return values between 6 and 18",
//                SensorId = "SensorIdICB"
//            });

//            mockAPIService.Setup(x => x.ListSensorsFromAPI())
//                .Returns(Task.Run(() => mockSensorsFromAPI));
            
//            //arrange username
//            string loggeduser = "loggeduser";

//            // arrange actual controller
//            SensorControllerMock controller = new SensorControllerMock(loggeduser, mockDBService.Object, mockAPIService.Object);

//            //act
//            await controller.RegisterNewSensor(expected);

//            // assert
//            mockDBService.Verify(x => x.RegisterNewSensor(loggeduser, testSensor), Times.Once);
//        }

//        [TestMethod]
//        public async Task NotRegisterSensor_WhenMinPollingTimeIsLessThanAllowed()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            //arrange RegisterNewSensorViewModel
//            DateTime testDateTime1 = DateTime.Now;
//            Sensor testSensor = new Sensor
//            {
//                SensorId = 8,
//                Name = "dsadas",
//                DescriptionGivenByTheUser = "asdas",
//                MeasurementType = "C",
//                IsPublic = true,
//                OperatingRange = "This sensor will return values between 6 and 18",
//                MinValue = 13.4,
//                MaxValue = 14.4,
//                AddedOn = testDateTime1,
//                Measurements = new HashSet<Measurement>(),
//                SharedWith = new HashSet<ApplicationUser>()
//            };

//            DateTime testDateTime2 = DateTime.Now;
//            LastValue testLastValue = new LastValue
//            {
//                SensorId = 45,
//                Sensor = testSensor,
//                SensorIdICB = "SensorIdICB",
//                PollingInterval = 2, //invalid testing value
//                Value = "Value",
//                LastUpdatedOn = testDateTime2
//            };

//            testSensor.LastValue = testLastValue;

//            RegisterNewSensorViewModel expected = new RegisterNewSensorViewModel
//            {
//                Sensor = testSensor
//            };

//            //koleto. Zaradi validaciite
//            SensorType sensorType = new SensorType
//            {
//                Id = 342,
//                SensorIdICB = "SensorIdICB",
//                IsNumericValue = true,
//                MeasureType = "C",
//                MinPollingIntervalInSeconds = 20, //minimum
//                Tag = "Tag"
//            };

//            mockDBService.Setup(x => x.GetSpecificSensorType("SensorIdICB"))
//                .Returns(sensorType);

//            IDictionary<string, APISensorType> mockSensorsFromAPI = new Dictionary<string, APISensorType>();

//            mockSensorsFromAPI.Add("SensorIdICB", new APISensorType()
//            {
//                Tag = "Tag",
//                MinPollingIntervalInSeconds = 0,
//                MeasureType = "C",
//                Description = "This sensor will return values between 6 and 18",
//                SensorId = "SensorIdICB"
//            });

//            mockAPIService.Setup(x => x.ListSensorsFromAPI())
//                .Returns(Task.Run(() => mockSensorsFromAPI));
            
//            //arrange username
//            string loggeduser = "loggeduser";

//            // arrange actual controller
//            SensorControllerMock controller = new SensorControllerMock(loggeduser, mockDBService.Object, mockAPIService.Object);

//            //act
//            await controller.RegisterNewSensor(expected);

//            // assert
//            mockDBService.Verify(x => x.RegisterNewSensor(loggeduser, testSensor), Times.Never);
//        }
        
//        //[DataRow(-1.0, 20.99)]
//        //[DataRow(-1.0, 12.99)]
//        //[DataRow(10.0, 27.99)]
//        //[DataRow(20.0, -20.99)]
//        [TestMethod]
//        public async Task NotRegisterSensor_WhenUserSetMinOrMaxValueOutsideAllowed()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            //arrange RegisterNewSensorViewModel
//            DateTime testDateTime1 = DateTime.Now;
//            Sensor testSensor = new Sensor
//            {
//                SensorId = 8,
//                Name = "dsadas",
//                DescriptionGivenByTheUser = "asdas",
//                MeasurementType = "C",
//                IsPublic = true,
//                OperatingRange = "This sensor will return values between 6 and 18", //reference limits
//                MinValue = -1.0,
//                MaxValue = 12.99,
//                AddedOn = testDateTime1,
//                Measurements = new HashSet<Measurement>(),
//                SharedWith = new HashSet<ApplicationUser>()
//            };

//            DateTime testDateTime2 = DateTime.Now;
//            LastValue testLastValue = new LastValue
//            {
//                SensorId = 45,
//                Sensor = testSensor,
//                SensorIdICB = "SensorIdICB",
//                PollingInterval = 2222,
//                Value = "Value",
//                LastUpdatedOn = testDateTime2
//            };

//            testSensor.LastValue = testLastValue;

//            RegisterNewSensorViewModel expected = new RegisterNewSensorViewModel
//            {
//                Sensor = testSensor
//            };

//            //koleto. Zaradi validaciite
//            SensorType sensorType = new SensorType
//            {
//                Id = 342,
//                SensorIdICB = "SensorIdICB",
//                IsNumericValue = true,
//                MeasureType = "C",
//                MinPollingIntervalInSeconds = 20,
//                Tag = "Tag"
//            };

//            mockDBService.Setup(x => x.GetSpecificSensorType("SensorIdICB"))
//                .Returns(sensorType);

//            IDictionary<string, APISensorType> mockSensorsFromAPI = new Dictionary<string, APISensorType>();

//            mockSensorsFromAPI.Add("SensorIdICB", new APISensorType()
//            {
//                Tag = "Tag",
//                MinPollingIntervalInSeconds = 0,
//                MeasureType = "C",
//                Description = "This sensor will return values between 6 and 18",
//                SensorId = "SensorIdICB"
//            });

//            mockAPIService.Setup(x => x.ListSensorsFromAPI())
//                .Returns(Task.Run(() => mockSensorsFromAPI));

//            //arrange username
//            string loggeduser = "loggeduser";

//            // arrange actual controller
//            SensorControllerMock controller = new SensorControllerMock(loggeduser, mockDBService.Object, mockAPIService.Object);

//            //act
//            await controller.RegisterNewSensor(expected);

//            // assert
//            mockDBService.Verify(x => x.RegisterNewSensor(loggeduser, testSensor), Times.Never);
//        }

//        public async Task NotRegisterSensor_WhenSensorIsBooleanAndNonZeroValuesAreSetToMinAndMaxValue()
//        {
//            // Arrange
//            // arrange controller
//            Mock<ApplicationDbContext> mockApplicationDbContext = new Mock<ApplicationDbContext>();

//            Mock<DBService> mockDBService = new Mock<DBService>(mockApplicationDbContext.Object);

//            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();
//            Mock<APIService> mockAPIService = new Mock<APIService>(mockHttpClient.Object);

//            //arrange RegisterNewSensorViewModel
//            DateTime testDateTime1 = DateTime.Now;
//            Sensor testSensor = new Sensor
//            {
//                SensorId = 8,
//                Name = "dsadas",
//                DescriptionGivenByTheUser = "asdas",
//                MeasurementType = "C",
//                IsPublic = true,
//                OperatingRange = "This sensor will return true or false value", //reference
//                MinValue = 13.4, //invalid testing value
//                MaxValue = 14.4, //invalid testing value
//                AddedOn = testDateTime1,
//                Measurements = new HashSet<Measurement>(),
//                SharedWith = new HashSet<ApplicationUser>()
//            };

//            DateTime testDateTime2 = DateTime.Now;
//            LastValue testLastValue = new LastValue
//            {
//                SensorId = 45,
//                Sensor = testSensor,
//                SensorIdICB = "SensorIdICB",
//                PollingInterval = 10,
//                Value = "Value",
//                LastUpdatedOn = testDateTime2
//            };

//            testSensor.LastValue = testLastValue;

//            RegisterNewSensorViewModel expected = new RegisterNewSensorViewModel
//            {
//                Sensor = testSensor
//            };

//            //koleto. Zaradi validaciite
//            SensorType sensorType = new SensorType
//            {
//                Id = 342,
//                SensorIdICB = "SensorIdICB",
//                IsNumericValue = true,
//                MeasureType = "C",
//                MinPollingIntervalInSeconds = 2,
//                Tag = "Tag"
//            };

//            mockDBService.Setup(x => x.GetSpecificSensorType("SensorIdICB"))
//                .Returns(sensorType);

//            IDictionary<string, APISensorType> mockSensorsFromAPI = new Dictionary<string, APISensorType>();

//            mockSensorsFromAPI.Add("SensorIdICB", new APISensorType()
//            {
//                Tag = "Tag",
//                MinPollingIntervalInSeconds = 0,
//                MeasureType = "C",
//                Description = "This sensor will return values between 6 and 18",
//                SensorId = "SensorIdICB"
//            });

//            mockAPIService.Setup(x => x.ListSensorsFromAPI())
//                .Returns(Task.Run(() => mockSensorsFromAPI));

//            //arrange username
//            string loggeduser = "loggeduser";

//            // arrange actual controller
//            SensorControllerMock controller = new SensorControllerMock(loggeduser, mockDBService.Object, mockAPIService.Object);

//            //act
//            await controller.RegisterNewSensor(expected);

//            // assert
//            mockDBService.Verify(x => x.RegisterNewSensor(loggeduser, testSensor), Times.Never);
//        }
        
//    }
//}