//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Contracts.DatabaseContexts;
//using Sensei.Data.DbService;
//using Sensei.Data.Models;
//using Sensei.Database.DbContext;
//using Sensei.Database.Models;
//using Sensei.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sensei.Tests.Database.DbServices.DBServiceTests
//{
//    [TestClass]
//    public class ListOwnSensors_Should
//    {
//        //[DataRow("user")]
//        [TestMethod]
//        public void ListsOwnUsers_WhenParametersAreCorrect()
//        {
//            string user = "user";
//            //Arrange
//            var ownSensors = new List<Sensor>()
//            {
//                new Sensor()
//                {
//                    ApplicationUser = new ApplicationUser() { UserName = "user" },
//                    Name = "sensor",
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
//                    ApplicationUser = new ApplicationUser() { UserName = "user" },
//                    Name = "sensor",
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

//            var users = new List<ApplicationUser>()
//            {
//                new ApplicationUser()
//                {
//                UserName = "user",
//                OwnedSensors = ownSensors
//                }
//            };

//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
//            dbContextMock.SetupGet(m => m.Users).Returns(usersDbSetMock.Object);

//            DBService service = new DBService(dbContextMock.Object);

//            //Act
//            var sensors = service.ListOwnSensors(user);

//            //Assert
//            Assert.IsNotNull(sensors);
//            dbContextMock.Verify(u => u.Users, Times.Once);
//            Assert.AreEqual(sensors.Count(), ownSensors.Count());
//        }
//    }
//}
