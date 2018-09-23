using Sensei.Data.Models.Intermediate;
using Sensei.Data.Models.Intermediate.Wrappers;
using System.Collections.Generic;

namespace Sensei.Data.DbService
{
    public interface IDbService
    {
        void UpdateSensorscCondition(List<FetchedSensorModels> fetchedSensors);

        WrappedPublicSensorsModel GetPublicSensorsFromDB();

        void CallDb();

        void RegisterNewSensor(RegisterNewSensorModel registerNewSensorModel);
    }
}