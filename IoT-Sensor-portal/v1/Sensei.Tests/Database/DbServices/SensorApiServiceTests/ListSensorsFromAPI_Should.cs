using Microsoft.VisualStudio.TestTools.UnitTesting;
using RichardSzalay.MockHttp;
using Sensei.Data.Models.Intermediate;
using Sensei.Services;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Tests.Database.DbServices.SensorApiServiceTests
{
    [TestClass]
    public class ListSensorsFromAPI_Should
    {
        [TestMethod]
        public async Task ReturnCollectionOfSensorsReadInData_WhenInvoked()
        {
            // Arrange - - - - - - - - - - -

            //Generate mock JSON
            SensorReadInData mockSensor1 = new SensorReadInData
            {
                Description = "Test Description",
                MeasureType = "Test MeasureType",
                MinPollingIntervalInSeconds = 7,
                SensorId = "Test SensorId",
                Tag = "Test Tag"
            };

            SensorReadInData mockSensor2 = new SensorReadInData
            {
                Description = "Description",
                MeasureType = "MeasureType",
                MinPollingIntervalInSeconds = 77,
                SensorId = "SensorId",
                Tag = "Tag"
            };

            IEnumerable<SensorReadInData> sensors = new List<SensorReadInData>() { mockSensor1, mockSensor2 };

            MemoryStream ms = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<SensorReadInData>));
            ser.WriteObject(ms, sensors);
            byte[] json = ms.ToArray();
            ms.Close();
            string expectedJSON = Encoding.UTF8.GetString(json, 0, json.Length); //mock JSON done

            //Generate mock HttpClient
            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
            string url = "http://telerikacademy.icb.bg/api/sensor/all";

            mockHttp.When(url).Respond("application/json", expectedJSON);

            HttpClient httpClient = new HttpClient(mockHttp);

            //injected mock HttpClient
            ISensorApiService sensorApiService = new SensorApiService(httpClient);

            IDictionary<string, SensorReadInData> expected = new Dictionary<string, SensorReadInData>();
            expected.Add(mockSensor1.SensorId, mockSensor1);
            expected.Add(mockSensor2.SensorId, mockSensor2);

            List<string> expectedKeys = expected.Keys.ToList();
            IList<SensorReadInData> expectedValues = expected.Values.ToList();

            // Act - - - - - - - - - - -
            IDictionary<string, SensorReadInData> actual = await sensorApiService.ListSensorsFromAPI();
            List<string> actualKeys = actual.Keys.ToList();
            IList<SensorReadInData> actualValues = actual.Values.ToList();

            // Assert - - - - - - - - - - -
            Assert.IsNotNull(actual);
            Assert.AreEqual(expected.Count, actual.Count);
            CollectionAssert.AreEquivalent(expectedKeys, actualKeys);

            for (int i = 0; i <= expectedValues.Count-1; i++)
            {
                Assert.AreEqual(expectedValues[i].Description, actualValues[i].Description);
                Assert.AreEqual(expectedValues[i].MeasureType, actualValues[i].MeasureType);
                Assert.AreEqual(expectedValues[i].MinPollingIntervalInSeconds, actualValues[i].MinPollingIntervalInSeconds);
                Assert.AreEqual(expectedValues[i].SensorId, actualValues[i].SensorId);
                Assert.AreEqual(expectedValues[i].Tag, actualValues[i].Tag);
            }
        }
    }
}
