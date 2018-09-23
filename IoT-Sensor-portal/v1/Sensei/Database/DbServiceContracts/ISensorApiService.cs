using Sensei.Data.Models;
using Sensei.Data.Models.Intermediate;
using Sensei.Database.Models;
using Sensei.Database.Models.Measurement_IO_models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Sensei.Services
{
    public interface ISensorApiService
    {
        Task<IDictionary<string, SensorReadInData>> ListSensorsFromAPI();

        Task<IEnumerable<string>> ListSupportedSensorTypesFromAPI();

        Task<MeasurementReadIn> GetCurrentSensorValueFromAPI(string SensorIdICB);
    }
}