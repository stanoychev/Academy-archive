//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Data.DbService;
//using Sensei.Data.Models;
//using Sensei.Database.DbContext;
//using Sensei.Database.Models;
//using Sensei.Models;
//using System.Collections.Generic;
//using System.Data.Entity;

//namespace Sensei.Tests.Database.DbServices.DBServiceTests
//{
//    [TestClass]
//    public class RegisterNewSensor_Should
//    //class RegisterNewSensor_Should
//    {
//        [TestMethod]
//        public void RegistersSensor_WhenParametersAreCorrect()
//        {
//            //Arrange
//            var sensor = new Sensor()
//            {
//                LastValue = new LastValue()
//            };
//            //var sensor = new Sensor();
//            var users = new List<ApplicationUser>()
//            {
//                new ApplicationUser()
//                {
//                    UserName = "user",
//                    OwnedSensors = new List<Sensor>() {sensor}
//                }
//            };

//            //var lastValue = new LastValue();

//            var sensorTypes = new List<SensorType>()
//            {
//                new SensorType()
//            };

//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var sensorTypesDbSetMock = new Mock<DbSet<SensorType>>().SetupData(sensorTypes);
//            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);

//            dbContextMock.SetupGet(c => c.SensorTypes).Returns(sensorTypesDbSetMock.Object);

//            //new line
//            dbContextMock.SetupGet(c => c.Users).Returns(usersDbSetMock.Object);

//            DBService service = new DBService(dbContextMock.Object);

//            //Act
//            service.RegisterNewSensor("user", sensor);
//            //service.RegisterNewSensor("user", sensor, lastValue);

//            //Assert
//            dbContextMock.Verify(d => d.SensorTypes, Times.Once);
//            dbContextMock.Verify(d => d.Users, Times.Once);
//            dbContextMock.Verify(d => d.SaveChanges(), Times.Once);
//        }
//    }
//}