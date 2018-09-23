using Bytes2you.Validation;
using Newtonsoft.Json;
using Sensei.Data.Models.Intermediate;
using Sensei.Database.Models.Measurement_IO_models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Sensei.Services
{
    public class SensorApiService : ISensorApiService
    {
        private const string coreURL = "http://telerikacademy.icb.bg/api/sensor/";
        private const string urlKey = "auth-token";
        private const string urlValue = "8e4c46fe-5e1d-4382-b7fc-19541f7bf3b0";
        private readonly HttpClient httpClient;

        public SensorApiService(HttpClient httpClient)
        {
            this.httpClient = httpClient ?? throw new ArgumentNullException("httpClient in SensorApiService");
            this.httpClient.DefaultRequestHeaders.Add(urlKey, urlValue);
        }

        public virtual async Task<IDictionary<string, SensorReadInData>> ListSensorsFromAPI()
        {
            string url = string.Format("{0}{1}", coreURL, "all");
            var response = await this.httpClient.GetAsync(url);
            //error handling?

            string jsonString = await response.Content.ReadAsStringAsync();
            IEnumerable<SensorReadInData> availableSensors = JsonConvert.DeserializeObject<IEnumerable<SensorReadInData>>(jsonString);

            IDictionary<string, SensorReadInData> output = new Dictionary<string, SensorReadInData>();

            foreach (SensorReadInData item in availableSensors)
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
            IEnumerable<SensorReadInData> availableSensors = JsonConvert.DeserializeObject<IEnumerable<SensorReadInData>>(jsonString);

            //ICollection<{SensorIdICB}>
            ICollection<string> output = new List<string>();

            foreach (SensorReadInData item in availableSensors)
            {
                output.Add(item.SensorId);
            }

            return output;
        }

        public virtual async Task<MeasurementReadIn> GetCurrentSensorValueFromAPI(string SensorIdICB)
        {
            Guard.WhenArgument(SensorIdICB, "SensorIdICB in SensorApiService.GetCurrentSensorValueFromAPI").IsNull().Throw();

            string url = string.Format("{0}{1}", coreURL, SensorIdICB);
            string jsonString = await this.GetJson(url);
            MeasurementReadIn sensorCurrentValue = JsonConvert.DeserializeObject<MeasurementReadIn>(jsonString);

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