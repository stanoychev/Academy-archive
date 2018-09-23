//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using RichardSzalay.MockHttp;
//using Sensei.Data.Models.Intermediate;
//using Sensei.Services;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net.Http;
//using System.Runtime.Serialization.Json;
//using System.Text;
//using System.Threading.Tasks;

//namespace Sensei.Tests.Database.DbServices.APIServiceTests
//{
//    [TestClass]
//    public class ListSensorsFromAPI_Should
//    {
//        [TestMethod]
//        public async Task ReturnCollectionOfSensorsReadInData_WhenInvoked()
//        {
//            // Arrange - - - - - - - - - - -

//            //Generate mock JSON
//            APISensorType mockSensor1 = new APISensorType
//            {
//                Description = "Test Description",
//                MeasureType = "Test MeasureType",
//                MinPollingIntervalInSeconds = 7,
//                SensorId = "Test SensorId",
//                Tag = "Test Tag"
//            };

//            APISensorType mockSensor2 = new APISensorType
//            {
//                Description = "Description",
//                MeasureType = "MeasureType",
//                MinPollingIntervalInSeconds = 77,
//                SensorId = "SensorId",
//                Tag = "Tag"
//            };

//            IEnumerable<APISensorType> sensors = new List<APISensorType>() { mockSensor1, mockSensor2 };

//            MemoryStream ms = new MemoryStream();
//            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(IEnumerable<APISensorType>));
//            ser.WriteObject(ms, sensors);
//            byte[] json = ms.ToArray();
//            ms.Close();
//            string expectedJSON = Encoding.UTF8.GetString(json, 0, json.Length); //mock JSON done

//            //Generate mock HttpClient
//            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
//            string url = "http://telerikacademy.icb.bg/api/sensor/all";

//            mockHttp.When(url).Respond("application/json", expectedJSON);

//            HttpClient httpClient = new HttpClient(mockHttp);

//            //injected mock HttpClient
//            IAPIService APIService = new APIService(httpClient);

//            IDictionary<string, APISensorType> expected = new Dictionary<string, APISensorType>();
//            expected.Add(mockSensor1.SensorId, mockSensor1);
//            expected.Add(mockSensor2.SensorId, mockSensor2);

//            List<string> expectedKeys = expected.Keys.ToList();
//            IList<APISensorType> expectedValues = expected.Values.ToList();

//            // Act - - - - - - - - - - -
//            IDictionary<string, APISensorType> actual = await APIService.ListSensorsFromAPI();
//            List<string> actualKeys = actual.Keys.ToList();
//            IList<APISensorType> actualValues = actual.Values.ToList();

//            // Assert - - - - - - - - - - -
//            Assert.IsNotNull(actual);
//            Assert.AreEqual(expected.Count, actual.Count);
//            CollectionAssert.AreEquivalent(expectedKeys, actualKeys);

//            for (int i = 0; i <= expectedValues.Count-1; i++)
//            {
//                Assert.AreEqual(expectedValues[i].Description, actualValues[i].Description);
//                Assert.AreEqual(expectedValues[i].MeasureType, actualValues[i].MeasureType);
//                Assert.AreEqual(expectedValues[i].MinPollingIntervalInSeconds, actualValues[i].MinPollingIntervalInSeconds);
//                Assert.AreEqual(expectedValues[i].SensorId, actualValues[i].SensorId);
//                Assert.AreEqual(expectedValues[i].Tag, actualValues[i].Tag);
//            }
//        }
//    }
//}
