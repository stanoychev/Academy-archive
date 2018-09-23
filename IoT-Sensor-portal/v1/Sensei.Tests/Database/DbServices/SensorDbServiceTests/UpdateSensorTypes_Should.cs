//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Data.DbService;
//using Sensei.Data.Models;
//using Sensei.Data.Models.Intermediate;
//using Sensei.Database.DbContext;
//using Sensei.Database.Models;
//using Sensei.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sensei.Tests.Database.DbServices.SensorDbServiceTests
//{
//    [TestClass]
//    public class UpdateSensorTypes_Should
//    {
//        [TestMethod]
//        public void UdpatesSensorType_WhenParametersAreCorrect()
//        {
//            var sensorTypes = new List<SensorType>()
//            {
//                new SensorType()
//                {
//                    Tag = "Tag",
//                    SensorIdICB = "id",
//                    MeasureType = "%",
//                    MinPollingIntervalInSeconds = 30,
//                    IsNumericValue = true
//                },
//                new SensorType()
//                {
//                    Tag = "TagTwo",
//                    SensorIdICB = "icbIdTwo",
//                    MeasureType = "%",
//                    MinPollingIntervalInSeconds = 30,
//                    IsNumericValue = false
//                },
//                new SensorType()
//                {
//                    Tag = "TagThree",
//                    SensorIdICB = "icbIdThree",
//                    MeasureType = "%",
//                    MinPollingIntervalInSeconds = 30,
//                    IsNumericValue = true}
//            };

//            var sensors = new List<Sensor>()
//            {
//                new Sensor()
//                {
//                    SensorId = 1,
//                    Name = "sensor",
//                    SensorType = new SensorType(),
//                    MeasurementType = "%",
//                    LastValue = new LastValue() { Value = "60" },
//                    MinValue = 50,
//                    MaxValue =70
//                }
//            };

//            var sensor = new SensorReadInData() { Tag = "Tag" };
//            var dict = new Dictionary<string, SensorReadInData>();
//            dict.Add(sensor.Tag, sensor);

//            var users = new List<ApplicationUser>()
//            {
//                new ApplicationUser()
//                {
//                UserName = "user",
//                }
//            };

//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
//            var sensorsDbSetMock = new Mock<DbSet<Sensor>>().SetupData(sensors);
//            var sensorTypesDbSetMock = new Mock<DbSet<SensorType>>().SetupData(sensorTypes);


//            dbContextMock.SetupGet(m => m.Users).Returns(usersDbSetMock.Object);
//            dbContextMock.SetupGet(m => m.Sensors).Returns(sensorsDbSetMock.Object);
//            dbContextMock.SetupGet(m => m.SensorTypes).Returns(sensorTypesDbSetMock.Object);

//            SensorDbService service = new SensorDbService(dbContextMock.Object);

//            //Act
//            service.UpdateSensorTypes(dict);

//            //Assert
//            dbContextMock.Verify(c => c.SensorTypes, Times.Once);

//        }
//    }
//}
