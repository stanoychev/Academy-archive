using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Data.DbService;
using Sensei.Database.DbContext;
using Sensei.Models;
using System.Collections.Generic;
using System.Data.Entity;

namespace Sensei.Tests.Database.DbServices.SensorDbServiceTests
{
    [TestClass]
    public class ListAllUsers_Should
    {
        [TestMethod]
        public void ReturnsAllUsers_WhenParametersAreCorrect()
        {
            //Arrange
            var users = new List<ApplicationUser>()
            {
                new ApplicationUser()
                {
                    UserName = "userOne",
                },
                new ApplicationUser()
                {
                    UserName = "userTwo",
                },
                new ApplicationUser()
                {
                    UserName = "userThree",
                }
            };

            var dbContextMock = new Mock<ApplicationDbContext>();
            var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
            dbContextMock.SetupGet(u => u.Users).Returns(usersDbSetMock.Object);

            SensorDbService service = new SensorDbService(dbContextMock.Object);

            //Act
            var usersResult = service.ListAllUsers();

            //Assert
            Assert.IsNotNull(usersResult);
        }

        //[TestMethod]
        //public void ReturnsNull_WhenNoUsersPresent()
        //{
        //    //Arrange
        //    var users = new List<ApplicationUser>();

        //    var dbContextMock = new Mock<ApplicationDbContext>();
        //    var usersDbSetMock = new Mock<DbSet<ApplicationUser>>().SetupData(users);
        //    dbContextMock.SetupGet(u => u.Users).Returns(usersDbSetMock.Object);

        //    SensorDbService service = new SensorDbService(dbContextMock.Object);

        //    //Act
        //    var usersResult = service.ListAllUsers();

        //    //Assert
        //    Assert.AreEqual(usersResult,new List<ApplicationUser>());

        //}
    }
}
