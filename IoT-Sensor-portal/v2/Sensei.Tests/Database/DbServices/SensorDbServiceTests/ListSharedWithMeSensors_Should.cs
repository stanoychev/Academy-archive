//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Contracts.DatabaseContexts;
//using Sensei.Data.DbService;
//using Sensei.Data.Models;
//using Sensei.Database.DbContext;
//using Sensei.Database.Models;
//using Sensei.Models;
//using System.Collections.Generic;
//using System.Data.Entity;

//namespace Sensei.Tests.Database.SensorsDbContextTests
//{
//    [TestClass]
//    public class ListSharedWithMeSensors_Should
//    {

//        [TestMethod]
//        public void ListSharedWithMeSensors_WhenUserHasAny()
//        {
//            //Arrange
//            var sharedSensors = new List<Sensor>()
//            {
//                new Sensor()
//                {
//                    SensorId = 1,
//                    Name = "sensor",
//                    SensorType = new SensorType(){ Tag = " " },
//                    ApplicationUser = new ApplicationUser() {UserName = "user"},
//                    MeasurementType = "%",
//                    LastValue = new LastValue() { Value = "60" },
//                    MinValue = 50,
//                    MaxValue = 70
//                }
//            };

//            var users = new List<ApplicationUser>()
//            {
//                new ApplicationUser()
//                {
//                UserName = "user",
//                SharedWithMe = sharedSensors
//                }
//            };

//            var dbContextMock = new Mock<ApplicationDbContext>();
//            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
//            dbContextMock.SetupGet(m => m.Users).Returns(usersDbSetMock.Object);

//            DBService service = new DBService(dbContextMock.Object);

//            //Act
//            service.ListSharedWithMeSensors("user");

//            //Assert
//            dbContextMock.Verify(u => u.Users, Times.Once);
//        }
//    }
//}
