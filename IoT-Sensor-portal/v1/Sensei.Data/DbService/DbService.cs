
using Sensei.Data.Context;
using Sensei.Data.DbService;
using Sensei.Data.Models.Intermediate;
using Sensei.Data.Models.Intermediate.Wrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;

namespace Sensei.Data.DummiDbService
{
    public class DbService : IDbService
    {
        private readonly ISenseiDbContext senseiDbContext;

        public DbService(ISenseiDbContext senseiDbContext)
        {
            this.senseiDbContext = senseiDbContext ?? throw new ArgumentNullException("database in DBService");
        }
        
        public WrappedPublicSensorsModel GetPublicSensorsFromDB()
        {
            List<PublicSensorInformation> publicSensorInformation = new List<PublicSensorInformation>();
            Dictionary<string, SensorCurrentValues> publicSensorIDs = new Dictionary<string, SensorCurrentValues>();
            
            List<PublicSensorInformation> publicSensors = this.senseiDbContext.Sensors
                .Where(x => x.IsPublic == true)
                .Select(y => new PublicSensorInformation()
                {
                    SensorTag = y.Tag,
                    MeasurementType = y.MeasurementType,
                    MinValue = y.MinValue,
                    MaxValue = y.MaxValue,
                    UserName = y.CreatedBy.UserName,
                })
                .ToList();

            foreach (PublicSensorInformation item in publicSensors)
            {
                if (!publicSensorIDs.ContainsKey(item.SensorTag))
                {
                    publicSensorIDs.Add(item.SensorTag, new SensorCurrentValues());
                }
            }

            return new WrappedPublicSensorsModel()
            {
                PublicSensorInformation = publicSensorInformation,
                PublicSensorIDs = publicSensorIDs
            };
        }

        public void UpdateSensorscCondition(List<FetchedSensorModels> fetchedSensors)
        {
            //todo when history concept is clear
        }

        public void CallDb()
        {
            this.senseiDbContext.Sensors.ToList();
        }

        public void RegisterNewSensor(RegisterNewSensorModel registerNewSensorModel)
        {
            //todo
        }
    }
}