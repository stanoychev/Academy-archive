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
//    public class ListSupportedSensorTypesFromAPI_Shouldcs
//    {
//        [TestMethod]
//        public async Task ReturnCollectionOfSensorTypes_WhenInvoked()
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

//            List<string> expectedResult = new List<string>();
//            expectedResult.Add(mockSensor1.SensorId);
//            expectedResult.Add(mockSensor2.SensorId);
            
//            // Act - - - - - - - - - - -
//            IDictionary<string, APISensorType> actualSensors = await APIService.ListSensorsFromAPI();
//            List<string> actualResult = actualSensors.Keys.ToList();
            
//            // Assert - - - - - - - - - - -
//            Assert.IsNotNull(actualSensors);
//            Assert.AreEqual(expectedResult.Count, actualResult.Count);
//            CollectionAssert.AreEquivalent(expectedResult, actualResult);

//            for (int i = 0; i <=expectedResult.Count-1; i++)
//            {
//                Assert.AreEqual(expectedResult[i], actualResult[i]);
//            }
//        }
//    }
//}
