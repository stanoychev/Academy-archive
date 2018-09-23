using Sensei.Models.API;
using Sensei.Models.Database;
using Sensei.Models.Misc;
using Sensei.Models.View;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sensei.Services.Contracts
{
    public interface IDBService
    {
        IEnumerable<SensorDisplayData> ListPublicSensorsFromDB();

        void RegisterNewSensor(string username, RegisterNewSensor sensorModel);

        IEnumerable<LastValue> GetAllSensorsLastValues();

        void AddNewMeasurementsToDb(IEnumerable<History> measurements);

        IEnumerable<string> ListAllUsers();

        void UpdateSensorTypes(IDictionary<string, APISensorType> availableSensors);

        IEnumerable<SensorDisplayData> ListOwnSensors(string username);

        IEnumerable<SensorDisplayData> ListSharedWithMeSensors(string username);

        //IDictionary<int, IEnumerable<string>> MySensorsAndWithWhoAreTheySharedWith(string username);
        
        void DeleteSensor(int sensorId);

        Task<List<SensorDisplayData>> ListAllSensorsAsync();

        Task<SensorDisplayData> GetSpecificSensorDisplayDataAsync(int sensorId);

        void ModifySpecificSesnor(SensorDisplayData model);

        void ShareSensor(int sensorId, string username);

        SensorType GetSpecificSensorType(string sensorIdICB);

        GraphViewModel GetSensorHistory(SensorDisplayData sensor);

        bool BeingSharedWith(int sensorId, string username);

        IEnumerable<string> GetRegisteredSensorTypes();
    }
}