using Sensei.Contracts.DatabaseContexts;
using Sensei.Data.Models;
using Sensei.Data.Models.Intermediate;
using Sensei.Database.Models;
using Sensei.Database.Models.Measurement_IO_models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Helpers;
using Newtonsoft.Json;
using Sensei.Database.DbContext;
using Sensei.ViewModels;

namespace Sensei.Data.DbService
{
    public class SensorDbService : ISensorDbService
    {
        private readonly IApplicationDbContext dbContext;

        public SensorDbService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext in DBService");
        }

        public virtual IEnumerable<LastValueReadFromDbcs> GetAllSensorsLastValues()
        {
            IEnumerable<LastValueReadFromDbcs> allSensors = new List<LastValueReadFromDbcs>();

            allSensors = this.dbContext.LastValues
                .Where(x => DbFunctions.AddSeconds(x.LastUpdatedOn.Value, x.PollingInterval) < DateTime.Now)
                .Select(x => new LastValueReadFromDbcs
                {
                    SensorId = x.SensorId,
                    SensorIdICB = x.SensorIdICB,
                    Value = x.Value
                })
                .ToList();

            return allSensors;
        }

        public virtual IEnumerable<SensorDisplayData> ListPublicSensorsFromDB()
        {
            IEnumerable<SensorDisplayData> publicSensors = new List<SensorDisplayData>();

            publicSensors = this.dbContext.Sensors
                .Where(x => x.IsPublic)
                .Select(y => new SensorDisplayData
                {
                    SensorId = y.SensorId,
                    SensorName = y.Name,
                    UserName = y.ApplicationUser.UserName,
                    SensorTag = y.SensorType.Tag,
                    MeasurementType = y.MeasurementType,
                    LastValue = y.LastValue.Value,
                    MinValue = y.MinValue,
                    MaxValue = y.MaxValue
                })
                .ToList();

            return publicSensors;
        }

        public virtual void UpdateSensorTypes(IDictionary<string, SensorReadInData> availableSensorsFromAPI)
        {
            // guard

            IEnumerable<string> notRegistered =
                availableSensorsFromAPI.Keys.Except(this.dbContext.SensorTypes.Select(x => x.SensorIdICB));

            if (notRegistered == null || notRegistered.Count() == 0)
            {
                return;
            }
            else
            {
                foreach (string sensorId in notRegistered)
                {
                    SensorReadInData newSensorType = availableSensorsFromAPI[sensorId];

                    this.dbContext.SensorTypes.Add(new SensorType()
                    {
                        SensorIdICB = newSensorType.SensorId,
                        MeasureType = newSensorType.MeasureType,
                        MinPollingIntervalInSeconds = newSensorType.MinPollingIntervalInSeconds,
                        Tag = newSensorType.Tag,
                        IsNumericValue = newSensorType.Description.Split().Contains("between")
                    });
                }
            }

            this.dbContext.SaveChanges();
        }

        public virtual void RegisterNewSensor(string username, Sensor newSensor)
        {
            newSensor.AddedOn = DateTime.Now;

            newSensor.LastValue.Value = "initial value";
            newSensor.LastValue.LastUpdatedOn = DateTime.Now;

            newSensor.SensorType = this.dbContext.SensorTypes.First(x => x.SensorIdICB == newSensor.LastValue.SensorIdICB);

            this.dbContext.Users.First(x => x.UserName == username).OwnedSensors.Add(newSensor);

            this.dbContext.SaveChanges();
        }

        public virtual void AddNewMeasurementsToDb(IEnumerable<Measurement> measurements)
        {
            if (measurements.Count() != 0)
            {
                foreach (Measurement measurement in measurements)
                {
                    this.dbContext.Measurements.Add(measurement);
                    this.dbContext.LastValues.First(x => x.SensorId == measurement.SensorId).LastUpdatedOn =
                        DateTime.Now;
                    this.dbContext.LastValues.First(x => x.SensorId == measurement.SensorId).Value = measurement.Value;
                }

                this.dbContext.SaveChanges();
            }
        }

        public virtual IEnumerable<string> ListAllUsers()
        {
            IEnumerable<string> userList = new List<string>();

            userList = this.dbContext.Users.Select(x => x.UserName).ToList();

            return userList;
        }

        public virtual IEnumerable<SensorDisplayData> ListOwnSensors(string username)
        {
            IEnumerable<SensorDisplayData> ownSensors = new List<SensorDisplayData>();

            ownSensors = this.dbContext.Users
                .First(x => x.UserName == username)
                .OwnedSensors
                .Select(y => new SensorDisplayData()
                {
                    SensorId = y.SensorId,
                    SensorIdICB = y.SensorType.SensorIdICB,
                    UserName = username,
                    SensorName = y.Name,
                    SensorTag = y.SensorType.Tag,
                    MeasurementType = y.MeasurementType,
                    LastValue = y.LastValue.Value,
                    MinValue = y.MinValue,
                    MaxValue = y.MaxValue,
                    IsPublic = y.IsPublic
                })
                .ToList();

            return ownSensors;
        }

        public virtual IDictionary<int, IEnumerable<string>> MySensorsAndWithWhoAreTheySharedWith(string username)
        {
            IDictionary<int, IEnumerable<string>> mySensorsAndWhoAreTheySharedWith = this.dbContext.Sensors
                .Where(x => x.ApplicationUser.UserName == username)
                .ToDictionary(x => x.SensorId, x => x.SharedWith.Select(y => y.UserName));

            return mySensorsAndWhoAreTheySharedWith;
        }

        public virtual IEnumerable<SensorDisplayData> ListSharedWithMeSensors(string username)
        {
            IEnumerable<SensorDisplayData> output = this.dbContext.Users
                .First(u => u.UserName == username)
                .SharedWithMe
                .Select(y => new SensorDisplayData()
                {
                    SensorId = y.SensorId,
                    SensorName = y.Name,
                    UserName = y.ApplicationUser.UserName,
                    SensorTag = y.SensorType.Tag,
                    MeasurementType = y.MeasurementType,
                    LastValue = y.LastValue.Value,
                    MinValue = y.MinValue,
                    MaxValue = y.MaxValue
                })
                .ToList();

            return output;
        }

        public virtual void DeleteSensor(int sensorId)
        {
            var lastValue = dbContext.LastValues.Find(sensorId);
            dbContext.LastValues.Remove(lastValue);

            var sensor = dbContext.Sensors.Find(sensorId);
            dbContext.Sensors.Remove(sensor);

            dbContext.SaveChanges();
        }

        public virtual async Task<List<SensorDisplayData>> ListAllSensorsAsync()
        {
            return await dbContext.Sensors.Select(sensor => new SensorDisplayData
            {
                SensorId = sensor.SensorId,
                SensorIdICB = sensor.SensorType.SensorIdICB,
                UserName = sensor.ApplicationUser.UserName,
                SensorName = sensor.Name,
                SensorTag = sensor.SensorType.Tag,
                MeasurementType = sensor.MeasurementType,
                LastValue = sensor.LastValue.Value,
                MinValue = sensor.MinValue,
                MaxValue = sensor.MaxValue,
                IsPublic = sensor.IsPublic,
                PollingInterval = sensor.LastValue.PollingInterval,
                AddedOn = sensor.AddedOn,
                DescriptionGivenByTheUser = sensor.DescriptionGivenByTheUser
            }).ToListAsync();
        }

        public virtual async Task<SensorDisplayData> GetSpecificSensorDisplayDataAsync(int sensorId)
        {
            return await dbContext.Sensors.Select(sensor => new SensorDisplayData
            {
                SensorId = sensor.SensorId,
                SensorIdICB = sensor.SensorType.SensorIdICB,
                UserName = sensor.ApplicationUser.UserName,
                SensorName = sensor.Name,
                SensorTag = sensor.SensorType.Tag,
                MeasurementType = sensor.MeasurementType,
                LastValue = sensor.LastValue.Value,
                MinValue = sensor.MinValue,
                MaxValue = sensor.MaxValue,
                IsPublic = sensor.IsPublic,
                PollingInterval = sensor.LastValue.PollingInterval,
                AddedOn = sensor.AddedOn,
                DescriptionGivenByTheUser = sensor.DescriptionGivenByTheUser
            }).FirstOrDefaultAsync(x => x.SensorId == sensorId);
        }

        public virtual GraphViewModel GetSensorHistory(SensorDisplayData sensor)
        {
            var model = new GraphViewModel();

            model.DisplayData = sensor;
            model.JsonList = new List<string>();


            if (sensor.MeasurementType != "(true/false)")
            {
                foreach (var sensorHistory in dbContext.Sensors.Find(sensor.SensorId).Measurements.ToArray())
                {
                    model.JsonList.Add(
                        JsonConvert.SerializeObject(new DateValueViewModel(sensorHistory.Date, sensorHistory.Value)));
                }
            }
            else
            {
                foreach (var sensorHistory in dbContext.Sensors.Find(sensor.SensorId).Measurements.ToArray())
                {
                    if (sensorHistory.Value == "true")
                    {
                        model.JsonList.Add(
                            JsonConvert.SerializeObject(
                                new DateValueViewModel(sensorHistory.Date, "1")));
                    }
                    else
                    {
                        model.JsonList.Add(
                            JsonConvert.SerializeObject(
                                new DateValueViewModel(sensorHistory.Date, "0")));
                    }
                }
            }

            return model;
        }

        public virtual void ModifySpecificSesnor(SensorDisplayData model)
        {

            var sensor = dbContext.Sensors.FirstOrDefault(x => x.SensorId == model.SensorId);
            sensor.Name = model.SensorName;
            sensor.MinValue = model.MinValue;
            sensor.MaxValue = model.MaxValue;
            sensor.IsPublic = model.IsPublic;
            sensor.DescriptionGivenByTheUser = model.DescriptionGivenByTheUser;

            dbContext.SaveChanges();
        }

        public bool BeingSharedWith(int sensorId, string username)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.UserName == username);
            return dbContext.Sensors.Find(sensorId).SharedWith.Contains(user)
;
        }

        public virtual void ShareSensor(int sensorId, string username)
        {
            var sensor = dbContext.Sensors.FirstOrDefault(x => x.SensorId == sensorId);
            var user = dbContext.Users.FirstOrDefault(x => x.UserName == username);

            if (user == null || sensor == null)
            {
                throw new NullReferenceException("value is null");
            }

            sensor.SharedWith.Add(user);

            dbContext.SaveChanges();
        }
        
        public virtual SensorType GetSpecificSensorType(string sensorIdICB)
        {
            return this.dbContext.SensorTypes
                .First(x => x.SensorIdICB == sensorIdICB);
        }
    }
}