//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using Moq;
//using Newtonsoft.Json;
//using RichardSzalay.MockHttp;
//using Sensei.Tests.Tools.CustomMockClasses;
//using System;
//using System.IO;
//using System.Net.Http;
//using System.Runtime.Serialization.Json;
//using System.Text;
//using System.Threading.Tasks;
//using Sensei.Database.Models.Measurement_IO_models;
//using Sensei.Services;

//namespace Sensei.Tests.Database.DbServices.APIServiceTests
//{
//    [TestClass]
//    public class GetCurrentSensorValueFromAPI_Should
//    {
//        [TestMethod]
//        public void ReturnInstanceOfSensor_WhenInvoked()
//        {
//            // Arrange - - - - - - - - - - -

//            string sensorIdICB = "Test sensorIdICB";

//            //Generate mock JSON
//            APIMeasure expected = new APIMeasure
//            {
//                TimeStamp = "Test TimeStamp",
//                Value = "Test Value",
//                ValueType = "Test ValueType"
//            };

//            MemoryStream ms = new MemoryStream();
//            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(APIMeasure));
//            ser.WriteObject(ms, expected);
//            byte[] json = ms.ToArray();
//            ms.Close();
//            string expectedJSON = Encoding.UTF8.GetString(json, 0, json.Length); //mock JSON done

//            //Generate mock HttpClient
//            MockHttpMessageHandler mockHttp = new MockHttpMessageHandler();
//            string url = string.Format("http://telerikacademy.icb.bg/api/sensor/{0}", sensorIdICB);

//            mockHttp.When(url).Respond("application/json", expectedJSON);

//            HttpClient httpClient = new HttpClient(mockHttp);

//            //injected mock HttpClient
//            IAPIService APIService = new APIService(httpClient);

//            // Act - - - - - - - - - - -
//            APIMeasure actual = APIService.GetCurrentSensorValueFromAPI(sensorIdICB).Result;
            
//            // Assert - - - - - - - - - - -
//            Assert.AreEqual(expected.TimeStamp, actual.TimeStamp);
//            Assert.AreEqual(expected.Value, actual.Value);
//            Assert.AreEqual(expected.ValueType, actual.ValueType);
//        }

//        [TestMethod]
//        public async Task ReturnAnInstance_WhenInvoked()
//        {
//            // Arrange - - - - - - - - - - -
//            string mockSensorId = "mockSensorId";
//            APIMeasure expectedResult = new APIMeasure
//            {
//                TimeStamp = "Test TimeStamp",
//                Value = "Test Value",
//                ValueType = "Test ValueType"
//            };
//            var mockHttpClient = new Mock<HttpClient>();

//            // Act - - - - - - - - - - -
//            APIServiceMock APIService = new APIServiceMock(mockHttpClient.Object, JsonConvert.SerializeObject(expectedResult));

//            APIMeasure testOutput = await APIService.GetCurrentSensorValueFromAPI(mockSensorId);
//            // Assert - - - - - - - - - - -
//            Assert.AreEqual(expectedResult.TimeStamp, testOutput.TimeStamp);
//            Assert.AreEqual(expectedResult.Value, testOutput.Value);
//            Assert.AreEqual(expectedResult.ValueType, testOutput.ValueType);
//        }

//        [TestMethod]
//        public void ThrowArgumentNullException_WhenParameterIsNull()
//        {
//            //arrange
//            string nullSensorIdICB = null;
//            Mock<HttpClient> mockHtteClient = new Mock<HttpClient>();
//            APIService APIService = new APIService(mockHtteClient.Object);
//            APIMeasure APIMeasure = new APIMeasure();

//            //act and assert
//            Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>  APIMeasure = await APIService.GetCurrentSensorValueFromAPI(nullSensorIdICB));
//        }
//    }
//}
