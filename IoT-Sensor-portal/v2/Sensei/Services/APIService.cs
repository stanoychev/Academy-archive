using Bytes2you.Validation;
using Newtonsoft.Json;
using Sensei.Models.API;
using Sensei.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sensei.Services
{
    public class APIService : IAPIService
    {
        private const string coreURL = "http://telerikacademy.icb.bg/api/sensor/";
        private const string urlKey = "auth-token";
        private const string urlValue = "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0";
        private readonly HttpClient httpClient;

        public APIService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException("httpClient in APIService");
            this.httpClient.DefaultRequestHeaders.Add(urlKey, urlValue);
        }

        public virtual async Task<IDictionary<string, APISensorType>> ListSensorsFromAPI()
        {
            string url = string.Format("{0}{1}", coreURL, "all");
            var response = await this.httpClient.GetAsync(url);
            //error handling?

            string jsonString = await response.Content.ReadAsStringAsync();
            IEnumerable<APISensorType> availableSensors = JsonConvert.DeserializeObject<IEnumerable<APISensorType>>(jsonString);

            IDictionary<string, APISensorType> output = new Dictionary<string, APISensorType>();

            foreach (APISensorType item in availableSensors)
            {
                output.Add(item.SensorId, item);
            }

            return output;
        }

        public virtual async Task<IEnumerable<string>> ListSupportedSensorTypesFromAPI()
        {
            string url = string.Format("{0}{1}", coreURL, "all");
            var response = await this.httpClient.GetAsync(url);
            //error handling?

            string jsonString = await response.Content.ReadAsStringAsync();
            IEnumerable<APISensorType> availableSensors = JsonConvert.DeserializeObject<IEnumerable<APISensorType>>(jsonString);

            //ICollection<{SensorIdICB}>
            ICollection<string> output = new List<string>();

            foreach (APISensorType item in availableSensors)
            {
                output.Add(item.SensorId);
            }

            return output;
        }

        public virtual async Task<APIMeasure> GetCurrentSensorValueFromAPI(string SensorIdICB)
        {
            Guard.WhenArgument(SensorIdICB, "SensorIdICB in APIService.GetCurrentSensorValueFromAPI").IsNull().Throw();

            string url = string.Format("{0}{1}", coreURL, SensorIdICB);
            string jsonString = await this.GetJson(url);
            APIMeasure sensorCurrentValue = JsonConvert.DeserializeObject<APIMeasure>(jsonString);

            return sensorCurrentValue;
        }

        protected virtual async Task<string> GetJson(string url)
        {
            var response = await this.httpClient.GetAsync(url);
            //error handling?

            string jsonString = await response.Content.ReadAsStringAsync();
            return jsonString;
        }
    }
}