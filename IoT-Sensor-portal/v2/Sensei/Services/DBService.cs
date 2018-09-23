using Newtonsoft.Json;
using Sensei.Database;
using Sensei.Models.API;
using Sensei.Models.Database;
using Sensei.Models.Misc;
using Sensei.Models.View;
using Sensei.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Sensei.Services
{
    public class DBService : IDBService
    {
        private readonly ApplicationDbContext dbContext;

        public DBService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext in DBService");
        }
        
        public virtual IEnumerable<LastValue> GetAllSensorsLastValues()
        {
            IEnumerable<LastValue> allSensors = this.dbContext.LastValues
                .Where(x => DbFunctions.AddSeconds(x.From.Value, x.PollingInterval) < DateTime.Now)
                .Select(x => new
                {
                    SensorId = x.SensorId,
                    SensorIdICB = x.SensorIdICB,
                    Value = x.Value,
                    From = x.From
                })
                .ToList()
                .Select(x => new LastValue
                {
                    SensorId = x.SensorId,
                    SensorIdICB = x.SensorIdICB,
                    Value = x.Value,
                    From = x.From
                });

            return allSensors;
        }

        public virtual IEnumerable<SensorDisplayData> ListPublicSensorsFromDB()
        {
            IEnumerable<SensorDisplayData> publicSensors = new List<SensorDisplayData>();

            publicSensors = this.dbContext.Sensors
                .Where(x => x.IsPublic)
                .Select(y => new SensorDisplayData
                {
                    SensorId = y.Id,
                    SensorName = y.UserDefinedSensorName,
                    UserName = y.ApplicationUser.UserName,
                    SensorTag = y.SensorType.Tag,
                    MeasurementType = y.UserDefinedMeasureType,
                    LastValue = y.LastValue.Value,
                    MinValue = y.UserDefinedMinValue,
                    MaxValue = y.UserDefinedMaxValue
                })
                .ToList();

            return publicSensors;
        }

        public virtual void UpdateSensorTypes(IDictionary<string, APISensorType> availableSensorsFromAPI)
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
                    APISensorType newSensorType = availableSensorsFromAPI[sensorId];

                    this.dbContext.SensorTypes.Add(new SensorType()
                    {
                        SensorIdICB = newSensorType.SensorId,
                        MeasureType = newSensorType.MeasureType,
                        MinPollingIntervalInSeconds = newSensorType.MinPollingIntervalInSeconds,
                        Tag = newSensorType.Tag,
                        Description = newSensorType.Description,
                        IsNumericValue = newSensorType.Description.Split().Contains("between")
                    });
                }
            }

            this.dbContext.SaveChanges();
        }

        public virtual void RegisterNewSensor(string username, RegisterNewSensor sensorModel)
        {
            Sensor sensor = new Sensor
            {
                UserDefinedSensorName = sensorModel.UserDefinedSensorName,
                UserDefinedDescription = sensorModel.UserDefinedDescription,
                UserDefinedMeasureType = sensorModel.UserDefinedMeasureType,
                UserDefinedMaxValue = sensorModel.UserDefinedMaxValue,
                UserDefinedMinValue = sensorModel.UserDefinedMinValue,
                IsPublic = sensorModel.IsPublic,
                AddedOn = DateTime.Now,
                SensorType = this.dbContext.SensorTypes.First(x => x.SensorIdICB == sensorModel.SensorIdICB),
                LastValue = new LastValue
                {
                    SensorIdICB = sensorModel.SensorIdICB,
                    PollingInterval = sensorModel.PollingInterval,
                    Value = "initial value",
                    From = DateTime.Now
                }
            };

            this.dbContext.Users.First(x => x.UserName == username).OwnedSensors.Add(sensor);

            this.dbContext.SaveChanges();
        }

        public virtual void AddNewMeasurementsToDb(IEnumerable<History> measurements)
        {
            if (measurements.Count() != 0)
            {
                foreach (History measurement in measurements)
                {
                    this.dbContext.Measurements.Add(measurement);
                    this.dbContext.LastValues.First(x => x.SensorId == measurement.SensorId).From =
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
                    SensorId = y.Id,
                    SensorIdICB = y.SensorType.SensorIdICB,
                    UserName = username,
                    SensorName = y.UserDefinedSensorName,
                    SensorTag = y.SensorType.Tag,
                    MeasurementType = y.UserDefinedMeasureType,
                    LastValue = y.LastValue.Value,
                    MinValue = y.UserDefinedMinValue,
                    MaxValue = y.UserDefinedMaxValue,
                    IsPublic = y.IsPublic
                })
                .ToList();

            return ownSensors;
        }

        //too big potential for deletion
        //public virtual IDictionary<int, IEnumerable<string>> MySensorsAndWithWhoAreTheySharedWith(string username)
        //{
        //    IDictionary<int, IEnumerable<string>> mySensorsAndWhoAreTheySharedWith = this.dbContext.Sensors
        //        .Where(x => x.ApplicationUser.UserName == username)
        //        .ToDictionary(x => x.Id, x => x.SharedWith.Select(y => y.UserName));

        //    return mySensorsAndWhoAreTheySharedWith;
        //}

        public virtual IEnumerable<SensorDisplayData> ListSharedWithMeSensors(string username)
        {
            IEnumerable<SensorDisplayData> output = this.dbContext.Users
                .First(u => u.UserName == username)
                .SharedWithMe
                .Select(y => new SensorDisplayData()
                {
                    SensorId = y.Id,
                    SensorName = y.UserDefinedSensorName,
                    UserName = y.ApplicationUser.UserName,
                    SensorTag = y.SensorType.Tag,
                    MeasurementType = y.UserDefinedMeasureType,
                    LastValue = y.LastValue.Value,
                    MinValue = y.UserDefinedMinValue,
                    MaxValue = y.UserDefinedMaxValue
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
                SensorId = sensor.Id,
                SensorIdICB = sensor.SensorType.SensorIdICB,
                UserName = sensor.ApplicationUser.UserName,
                SensorName = sensor.UserDefinedSensorName,
                SensorTag = sensor.SensorType.Tag,
                MeasurementType = sensor.UserDefinedMeasureType,
                LastValue = sensor.LastValue.Value,
                MinValue = sensor.UserDefinedMinValue,
                MaxValue = sensor.UserDefinedMaxValue,
                IsPublic = sensor.IsPublic,
                PollingInterval = sensor.LastValue.PollingInterval,
                AddedOn = sensor.AddedOn,
                DescriptionGivenByTheUser = sensor.UserDefinedDescription
            }).ToListAsync();
        }

        public virtual async Task<SensorDisplayData> GetSpecificSensorDisplayDataAsync(int sensorId)
        {
            return await dbContext.Sensors.Select(sensor => new SensorDisplayData
            {
                SensorId = sensor.Id,
                SensorIdICB = sensor.SensorType.SensorIdICB,
                UserName = sensor.ApplicationUser.UserName,
                SensorName = sensor.UserDefinedSensorName,
                SensorTag = sensor.SensorType.Tag,
                MeasurementType = sensor.UserDefinedMeasureType,
                LastValue = sensor.LastValue.Value,
                MinValue = sensor.UserDefinedMinValue,
                MaxValue = sensor.UserDefinedMaxValue,
                IsPublic = sensor.IsPublic,
                PollingInterval = sensor.LastValue.PollingInterval,
                AddedOn = sensor.AddedOn,
                DescriptionGivenByTheUser = sensor.UserDefinedDescription
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
                        JsonConvert.SerializeObject(new DateValueViewModel(sensorHistory.From, sensorHistory.Value)));
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
                                new DateValueViewModel(sensorHistory.From, "1")));
                    }
                    else
                    {
                        model.JsonList.Add(
                            JsonConvert.SerializeObject(
                                new DateValueViewModel(sensorHistory.From, "0")));
                    }
                }
            }

            return model;
        }

        public virtual void ModifySpecificSesnor(SensorDisplayData model)
        {

            var sensor = dbContext.Sensors.FirstOrDefault(x => x.Id == model.SensorId);
            sensor.UserDefinedSensorName = model.SensorName;
            sensor.UserDefinedMinValue = model.MinValue;
            sensor.UserDefinedMaxValue = model.MaxValue;
            sensor.IsPublic = model.IsPublic;
            sensor.UserDefinedDescription = model.DescriptionGivenByTheUser;

            dbContext.SaveChanges();
        }

        public virtual bool BeingSharedWith(int sensorId, string username)
        {
            var user = dbContext.Users.FirstOrDefault(x => x.UserName == username);
            return dbContext.Sensors.Find(sensorId).SharedWith.Contains(user)
;
        }

        public virtual void ShareSensor(int sensorId, string username)
        {
            var sensor = dbContext.Sensors.FirstOrDefault(x => x.Id == sensorId);
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

        public virtual IEnumerable<string> GetRegisteredSensorTypes()
        {
            return this.dbContext.SensorTypes.Select(x => x.SensorIdICB).ToList();
        }
    }
}