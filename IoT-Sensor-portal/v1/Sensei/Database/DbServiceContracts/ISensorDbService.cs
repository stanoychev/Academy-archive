using Sensei.Data.Models;
using Sensei.Data.Models.Intermediate;
using Sensei.Database.Models;
using Sensei.Database.Models.Measurement_IO_models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Sensei.ViewModels;

namespace Sensei.Data.DbService
{
    public interface ISensorDbService
    {
        IEnumerable<SensorDisplayData> ListPublicSensorsFromDB();
        
        void RegisterNewSensor(string username, Sensor newSensor);

        IEnumerable<LastValueReadFromDbcs> GetAllSensorsLastValues();

        void AddNewMeasurementsToDb(IEnumerable<Measurement> measurements);
        
        IEnumerable<string> ListAllUsers();

        void UpdateSensorTypes(IDictionary<string, SensorReadInData> availableSensors);

        IEnumerable<SensorDisplayData> ListOwnSensors(string username);
        
        IEnumerable<SensorDisplayData> ListSharedWithMeSensors(string username);

        IDictionary<int, IEnumerable<string>> MySensorsAndWithWhoAreTheySharedWith(string username);

        //void ShareOwnSensors(string username, IDictionary<int, IEnumerable<string>> usersToShareMySensorsWith);

        void DeleteSensor(int sensorId);

        Task<List<SensorDisplayData>> ListAllSensorsAsync();

        Task<SensorDisplayData> GetSpecificSensorDisplayDataAsync(int sensorId);

        void ModifySpecificSesnor(SensorDisplayData model);

        void ShareSensor(int sensorId, string username);
        
        SensorType GetSpecificSensorType(string sensorIdICB);

        GraphViewModel GetSensorHistory(SensorDisplayData sensor);

        bool BeingSharedWith(int sensorId, string username);
    }
}