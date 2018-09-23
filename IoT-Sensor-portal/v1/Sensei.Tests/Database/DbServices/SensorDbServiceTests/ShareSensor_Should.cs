using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Data.DbService;
using Sensei.Data.Models;
using Sensei.Database.DbContext;
using Sensei.Database.Models;
using Sensei.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Tests.Database.DbServices.SensorDbServiceTests
{
    [TestClass]
    public class ShareSensor_Should
    {
        //[DataRow(1, "user")] because of Jenkins
        [TestMethod]
        public void SharesASensor_WhenParametersAreCorrect()
        {
            int sensorId = 1;
            string username = "user";

            var sensors = new List<Sensor>()
            {
                new Sensor()
                {
                    SensorId = 1,
                    Name = "sensor",
                    SensorType = new SensorType(),
                    MeasurementType = "%",
                    LastValue = new LastValue() { Value = "60" },
                    MinValue = 50,
                    MaxValue =70
                }
            };

            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                UserName = username,
                }
            };

            var dbContextMock = new Mock<ApplicationDbContext>();
            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
            var sensorsDbSetMock = new Mock<DbSet<Sensor>>().SetupData(sensors);

            dbContextMock.SetupGet(m => m.Users).Returns(usersDbSetMock.Object);
            dbContextMock.SetupGet(m => m.Sensors).Returns(sensorsDbSetMock.Object);

            SensorDbService service = new SensorDbService(dbContextMock.Object);

            //Act
            service.ShareSensor(sensorId, username);
            //var sharedSensor = dbContextMock.Object.Users.First(u => u.UserName == username).SharedWithMe.Last();
            //var sharedSens = dbContextMock.Object.Sensors.First(s => s.SensorId == sensorId).SharedWith.First();


            dbContextMock.Verify(c => c.Users, Times.Once);
            dbContextMock.Verify(c => c.Sensors, Times.Once);
            //Assert.AreEqual(sharedSens, sensors[0]);
        }
    }
}
