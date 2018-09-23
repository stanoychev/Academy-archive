using Sensei.Models.API;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensei.Services.Contracts
{
    public interface IAPIService
    {
        Task<IDictionary<string, APISensorType>> ListSensorsFromAPI();

        Task<IEnumerable<string>> ListSupportedSensorTypesFromAPI();

        Task<APIMeasure> GetCurrentSensorValueFromAPI(string SensorIdICB);
    }
}