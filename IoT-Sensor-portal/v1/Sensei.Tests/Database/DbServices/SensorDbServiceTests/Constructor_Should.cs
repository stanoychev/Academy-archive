//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Sensei.Contracts.DatabaseContexts;
//using Sensei.Data.DbService;
//using Sensei.Database.DbContext;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sensei.Tests.Database.DbServices.SensorDbServiceTests
//{
//    [TestClass]
//    public class Constructor_Should
//    {
//        [TestMethod]
//        public void ServiceIsCreated_WhenCorrectParametersArePassed()
//        {
//            //Arrange
//            var dbContextMock = new Mock<ApplicationDbContext>();
//            ISensorDbService service = new SensorDbService(dbContextMock.Object);

//            //Act and Assert
//            Assert.IsNotNull(service);
//        }

//        [TestMethod]
//        public void ServiceIsNotCreated_WhenIncorrectParametersArePassed()
//        {
//            //Arrange, act and assert
//            Assert.ThrowsException<ArgumentNullException>(() =>
//            new SensorDbService(null));
//        }
//    }
//}
