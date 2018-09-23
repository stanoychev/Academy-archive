using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Sensei.Services;
using System;
using System.Net.Http;

namespace Sensei.Tests.Database.DbServices.SensorApiServiceTests
{
    [TestClass]
    public class Constructor_Should
    {
        [TestMethod]
        public void ReturnInstance_WhenParameterIsCorrect()
        {
            // Arrange
            Mock<HttpClient> mockHttpClient = new Mock<HttpClient>();

            // Act
            SensorApiService instance = new SensorApiService(mockHttpClient.Object);

            // Assert
            Assert.IsNotNull(instance);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParameterIsNotCorrect()
        {
            // Arrange
            HttpClient mockHttpClient = null;

            // Act
            // Assert
            Assert.ThrowsException<ArgumentNullException>(() => new SensorApiService(mockHttpClient));
        }
    }
}
