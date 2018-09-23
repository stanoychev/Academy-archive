//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Contracts.DatabaseContexts;
//using Sensei.Data.DbService;
//using Sensei.Data.Models;
//using Sensei.Data.Models.Intermediate;
//using Sensei.Database.DbContext;
//using Sensei.Database.Models;
//using Sensei.Models;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data.Entity;

//namespace Sensei.Tests.Database.DbServices.DBServiceTests
//{
//    [TestClass]
//    public class GetSpecificSensor_Should
//    {
//        //[DataRow(1)]
//        //[DataRow(2)]
//        [TestMethod]
//        public void CreatesSensor_WhenInputIsCorrect()
//        {
//            int sensorId = 1;
//            var sensors = new List<Sensor>()
//            {
//                new Sensor()
//                {
//                    SensorId = 1,
//                    ApplicationUser = new ApplicationUser() { UserName = "user" },
//                    Name = "sensorOne",
//                    SensorType = new SensorType() {SensorIdICB = "idIcb", Tag= "tag" },
//                    MeasurementType = "%",
//                    LastValue = new LastValue() { Value = "60", PollingInterval = 20 },
//                    OperatingRange = "",
//                    AddedOn = DateTime.Now,
//                    MinValue = 50,
//                    MaxValue =70,
//                    IsPublic = true,
//                    DescriptionGivenByTheUser = "description"
//                },
//                new Sensor()
//                {
//                    SensorId = 2,
//                    ApplicationUser = new ApplicationUser() { UserName = "user" },
//                    Name = "sensorTwo",
//                    SensorType = new SensorType() {SensorIdICB = "idIcb", Tag= "tag" },
//                    MeasurementType = "%",
//                    LastValue = new LastValue() { Value = "50", PollingInterval = 20 },
//                    OperatingRange = "",
//                    AddedOn = DateTime.Now,
//                    MinValue = 40,
//                    MaxValue = 60,
//                    IsPublic = true,
//                    DescriptionGivenByTheUser = "description"
//                },
//            };

//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var sensorsDbSetMock = new Mock<DbSet<Sensor>>().SetupData(sensors);

//            dbContextMock.SetupGet(m => m.Sensors).Returns(sensorsDbSetMock.Object);

//            DBService service = new DBService(dbContextMock.Object);

//            //Act
//            service.GetSpecificSensorDisplayDataAsync(sensorId);

//            //Assert
//            dbContextMock.Verify(c => c.Sensors, Times.Once);

//            //var expectedSensorDisplayData = new SensorDisplayData()
//            //{
//            //    SensorIdICB = personalSensors[0].SensorType.SensorIdICB,
//            //    UserName = personalSensors[0].ApplicationUser.UserName,
//            //    SensorName = personalSensors[0].Name,
//            //    SensorTag = personalSensors[0].SensorType.Tag,
//            //    MeasurementType = personalSensors[0].MeasurementType,
//            //    LastValue = personalSensors[0].LastValue.Value,
//            //    MinValue = personalSensors[0].MinValue,
//            //    MaxValue = personalSensors[0].MaxValue,
//            //    IsPublic = personalSensors[0].IsPublic,
//            //    PollingInterval = personalSensors[0].LastValue.PollingInterval,
//            //    OperatingRange = personalSensors[0].OperatingRange,
//            //    AddedOn = personalSensors[0].AddedOn,
//            //    DescriptionGivenByTheUser = personalSensors[0].DescriptionGivenByTheUser
//            //};

//            //        public virtual async Task<SensorDisplayData> GetSpecificSensorDisplayDataAsync(int sensorId)
//            //    {
//            //        return await dbContext.Sensors.Select(sensor => new SensorDisplayData
//            //        {
//            //            SensorId = sensor.SensorId,
//            //            SensorIdICB = sensor.SensorType.SensorIdICB,
//            //            UserName = sensor.ApplicationUser.UserName,
//            //            SensorName = sensor.Name,
//            //            SensorTag = sensor.SensorType.Tag,
//            //            MeasurementType = sensor.MeasurementType,
//            //            LastValue = sensor.LastValue.Value,
//            //            MinValue = sensor.MinValue,
//            //            MaxValue = sensor.MaxValue,
//            //            IsPublic = sensor.IsPublic,
//            //            PollingInterval = sensor.LastValue.PollingInterval,
//            //            AddedOn = sensor.AddedOn,
//            //            DescriptionGivenByTheUser = sensor.DescriptionGivenByTheUser
//            //        }).FirstOrDefaultAsync(x => x.SensorId == sensorId);
//            //    }
//        }
//    }
//}
