using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Data.DbService;
using Sensei.Data.Models;
using Sensei.Database.DbContext;
using Sensei.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Tests.Database.DbServices.SensorDbServiceTests
{
    [TestClass]
    public class AddMeasurementsToDb_Should
    {
        [TestMethod]
        public void AddsToDatabase_IfInputIsValud()
        {
            ICollection<Measurement> measurementsInDb = new List<Measurement>();

            IEnumerable<Measurement> measurementsToInsertInDb = new List<Measurement>()
            {
                new Measurement()
                {
                    Date = DateTime.Now,
                    MeasurementType = "%",
                    Value = "30",
                    SensorId = 1,
                    MeasurementId = 1
                },

                new Measurement()
                {
                    Date = DateTime.Now,
                    MeasurementType = "W",
                    Value = "1200",
                    SensorId = 1,
                    MeasurementId = 2
                },

                new Measurement()
                {
                    Date = DateTime.Now,
                    MeasurementType = "%",
                    Value = "70",
                    SensorId = 1,
                    MeasurementId = 3
                }
            };

            ICollection<LastValue> lastValuesInDb = new List<LastValue>()
            {
                new LastValue()
                {
                    SensorId = 1
                }
            };

            var mockDbContext = new Mock<ApplicationDbContext>();
            var measurementsDbSetMock = new Mock<DbSet<Measurement>>().SetupData(measurementsInDb);
            var lastValuesDbSetMock = new Mock<DbSet<LastValue>>().SetupData(lastValuesInDb);

            mockDbContext.SetupGet(c => c.Measurements).Returns(measurementsDbSetMock.Object);
            mockDbContext.SetupGet(c => c.LastValues).Returns(lastValuesDbSetMock.Object);

            SensorDbService service = new SensorDbService(mockDbContext.Object);

            //Act
            service.AddNewMeasurementsToDb(measurementsToInsertInDb);

            //Assert
            mockDbContext.Verify(c => c.Measurements, Times.Exactly(measurementsToInsertInDb.Count()));
            mockDbContext.Verify(c => c.LastValues, Times.Exactly(measurementsToInsertInDb.Count()*2));
            mockDbContext.Verify(c => c.SaveChanges(), Times.Once);

        }

    }
}
