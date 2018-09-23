using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;
using RichardSzalay.MockHttp;
using Sensei.Tests.Tools.CustomMockClasses;
using System;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;
using Sensei.Database.Models.Measurement_IO_models;
using Sensei.Services;

namespace Sensei.Tests.Database.DbServices.SensorApiServiceTests
{
    [TestClass]
    public class GetCurrentSensorValueFromAPI_Should
    {
        [TestMethod]
        public void ReturnInstanceOfSensor_WhenInvoked()
        {
            // Arrange - - - - - - - - - - -

            string sensorIdICB = "Test sensorIdICB";

            //Generate mock JSON
            MeasurementReadIn expected = new MeasurementReadIn
            {
                TimeStamp = "Test TimeStamp",
                Value = "Test Value",
                ValueType = "Test ValueType"
            };

            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(MeasurementReadIn));
            ser.WriteObject(ms, expected);
            byte[] json = ms.ToArray();
            ms.Close();
            string expectedJSON = Encoding.UTF8.GetString(json, 0, json.Length); //mock JSON done

            //Generate mock HttpClient
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            string url = string.Format("http://telerikacademy.icb.bg/api/sensor/{0}", sensorIdICB);

            mockHttp.When(url).Respond("application/json", expectedJSON);

            HttpClient httpClient = new HttpClient(mockHttp);

            //injected mock HttpClient
            ISensorApiService sensorApiService = new SensorApiService(httpClient);

            // Act - - - - - - - - - - -
            MeasurementReadIn actual = sensorApiService.GetCurrentSensorValueFromAPI(sensorIdICB).Result;
            
            // Assert - - - - - - - - - - -
            Assert.AreEqual(expected.TimeStamp, actual.TimeStamp);
            Assert.AreEqual(expected.Value, actual.Value);
            Assert.AreEqual(expected.ValueType, actual.ValueType);
        }

        [TestMethod]
        public async Task ReturnAnInstance_WhenInvoked()
        {
            // Arrange - - - - - - - - - - -
            string mockSensorId = "mockSensorId";
            MeasurementReadIn expectedResult = new MeasurementReadIn
            {
                TimeStamp = "Test TimeStamp",
                Value = "Test Value",
                ValueType = "Test ValueType"
            };
            var mockHttpClient = new Mock<HttpClient>();

            // Act - - - - - - - - - - -
            SensorApiServiceMock sensorApiService = new SensorApiServiceMock(mockHttpClient.Object, JsonConvert.SerializeObject(expectedResult));

            MeasurementReadIn testOutput = await sensorApiService.GetCurrentSensorValueFromAPI(mockSensorId);
            // Assert - - - - - - - - - - -
            Assert.AreEqual(expectedResult.TimeStamp, testOutput.TimeStamp);
            Assert.AreEqual(expectedResult.Value, testOutput.Value);
            Assert.AreEqual(expectedResult.ValueType, testOutput.ValueType);
        }

        [TestMethod]
        public void ThrowArgumentNullException_WhenParameterIsNull()
        {
            //arrange
            string nullSensorIdICB = null;
            Mock<HttpClient> mockHtteClient = new Mock<HttpClient>();
            SensorApiService sensorApiService = new SensorApiService(mockHtteClient.Object);
            MeasurementReadIn measurementReadIn = new MeasurementReadIn();

            //act and assert
            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>  measurementReadIn = await sensorApiService.GetCurrentSensorValueFromAPI(nullSensorIdICB));
        }
    }
}
