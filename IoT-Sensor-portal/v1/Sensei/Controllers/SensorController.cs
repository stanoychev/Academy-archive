using Sensei.Data.DbService;
using Sensei.Data.Models;
using Sensei.Data.Models.Intermediate;
using Sensei.Data.Models.Intermediate.Wrappers;
using Sensei.Database.Models;
using Sensei.Database.Models.Measurement_IO_models;
using Sensei.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Sensei.ViewModels;

namespace Sensei.Controllers
{
    public class SensorController : Controller
    {
        private readonly ISensorDbService sensorDbService;
        private readonly ISensorApiService sensorApiService;

        public SensorController(ISensorDbService sensorDbService, ISensorApiService sensorApiService)
        {
            this.sensorDbService = sensorDbService ?? throw new ArgumentNullException("DbService in SensorController");
            this.sensorApiService = sensorApiService ?? throw new ArgumentNullException("sensorDataFetchingService in SensorController");
        }

        [OutputCache(Duration = 30)]
        public async Task<ActionResult> RenderChart(int sensorId)
        {
            var sensor = await sensorDbService.GetSpecificSensorDisplayDataAsync(sensorId);

            if (!sensor.IsPublic)
            {
                if (GetLoggedUsername() != sensor.UserName)
                {
                    if (!sensorDbService.BeingSharedWith(sensorId, GetLoggedUsername()))
                    {
                        throw new HttpException(403, "Access denied");
                    }
                }
            }

            var model = sensorDbService.GetSensorHistory(sensor);

            return this.View("Charts/Chart", model);
        }

        public ActionResult ListAllPublicSensors()
        {
            IEnumerable<SensorDisplayData> publicSensors = this.sensorDbService.ListPublicSensorsFromDB();

            return this.View(publicSensors);
        }

        public async Task<ActionResult> DeleteSensor(int sensorId)
        {
            var sensorData = await sensorDbService.GetSpecificSensorDisplayDataAsync(sensorId);

            if (GetLoggedUsername() != sensorData.UserName)
            {
                throw new HttpException(403, "Access denied");
            }

            sensorDbService.DeleteSensor(sensorId);

            return PartialView("SensorPartialViews/_Nothing");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> RegisterNewSensor()
        {
            RegisterNewSensorViewModel sensorsFromApi = new RegisterNewSensorViewModel();

            //IDictionary<{SensorIdICB}, SensorType>
            IDictionary<string, SensorReadInData> availableSensorsFromAPI = await this.sensorApiService.ListSensorsFromAPI();
            this.sensorDbService.UpdateSensorTypes(availableSensorsFromAPI);

            IEnumerable<SensorReadInData> availableSensors = availableSensorsFromAPI.Values;

            sensorsFromApi.AvailableSensors = availableSensors;

            //to do later: check if sensors are no longer supported
            return this.View(sensorsFromApi);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public async Task<ActionResult> RegisterNewSensor(RegisterNewSensorViewModel wrappedRegisterNewSensorModel)
        {
            Sensor newSensor = wrappedRegisterNewSensorModel.Sensor;
            
            //validation
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("InvalidInput", new { message = "Invalid model state." });
            }

            if (newSensor.LastValue.SensorIdICB == null)
            {
                return this.RedirectToAction("InvalidInput", new { message = "Sensor ID cannot be empty." });
            }

            if (newSensor.Name == null)
            {
                return this.RedirectToAction("InvalidInput", new { message = "Name cannot be empty." });
            }
            
            try
            {
                SensorType serverSensorType = this.sensorDbService
                .GetSpecificSensorType(newSensor.LastValue.SensorIdICB);

                if (newSensor.LastValue.PollingInterval < serverSensorType.MinPollingIntervalInSeconds)
                {
                    return this.RedirectToAction("InvalidInput", new { message = "Invalid minimal polling interval." } );
                }

                //emergencyPatch. To Fix later - - - - - 
                //Fix here: In SensorTypes database model must be added OperationalRange property, from where to cross check the input min/max values
                IDictionary<string, SensorReadInData> emergencySensorsFromAPI = await this.sensorApiService.ListSensorsFromAPI();
                SensorReadInData serverSensor = emergencySensorsFromAPI[newSensor.LastValue.SensorIdICB];

                string operatingRange = serverSensor.Description;
                string[] substring = operatingRange.Split();

                //"This sensor will return values between 6 and 18" or "This sensor will return true or false value"
                if (substring.Contains("between"))
                {
                    //case sensor is integer type
                    double serverMinVal = double.Parse(substring[substring.Length - 3]);
                    double serverMaxVal = double.Parse(substring[substring.Length - 1]);

                    if (newSensor.MinValue >= serverMinVal && newSensor.MinValue <= serverMaxVal)
                    {
                    }
                    else
                    {
                        return this.RedirectToAction("InvalidInput", new { message = "Invalid sensor minimal value." });
                    }

                    if (newSensor.MaxValue <= serverMaxVal && newSensor.MaxValue >= serverMinVal)
                    {
                    }
                    else
                    {
                        return this.RedirectToAction("InvalidInput", new { message = "Invalid sensor maximum value." });
                    }
                }
                else
                {
                    //case sensor is boolean type
                    if (newSensor.MinValue != 0 || newSensor.MaxValue != 0)
                    {
                        return this.RedirectToAction("InvalidInput", new { message = "Invalid sensor min / maximum value when the sensor is boolean type." });
                    }
                }

                newSensor.MeasurementType = serverSensor.MeasureType;
                //newSensor.SensorType
            }
            catch
            {
                //this is if the user tries even entering invalid sensorIdICB just to brake the application
                return this.RedirectToAction("InvalidInput", new { message = "Invalid sensor ID." });
            }
            
            this.sensorDbService
                .RegisterNewSensor(GetLoggedUsername(), newSensor);
            
            return this.View("Success");
        }

        [Authorize]
        public ActionResult ListPersonalSensors()
        {
            string username = GetLoggedUsername();

            var model = this.sensorDbService.ListOwnSensors(username);

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShareSensor(int sensorId, string username)
        {
            try
            {
                sensorDbService.ShareSensor(sensorId, username);
            }
            catch (Exception)
            {
                return PartialView("SensorPartialViews/_FailedToShareSensor");
            }

            var model = sensorId;
            return PartialView("SensorPartialViews/_SuccessfulySharedSensor", model);
        }

        [Authorize]
        public ActionResult SharedSensors()
        {
            IEnumerable<SensorDisplayData> ListSharedWithMeSensors = this.sensorDbService.ListSharedWithMeSensors(this.User.Identity.Name);

            return this.View(ListSharedWithMeSensors);
        }

        [Authorize]
        public ActionResult ModifySensors()
        {
            var loggedUser = GetLoggedUsername();
            var model = sensorDbService.ListOwnSensors(loggedUser).ToList();

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> ModifySelectedSensor(int sensorId)
        {
            var loggedUser = GetLoggedUsername();
            var model = await sensorDbService.GetSpecificSensorDisplayDataAsync(sensorId);

            if (model.UserName != loggedUser)
            {
                throw new HttpException(403, "Unauthorized Access");
            }
            
            return PartialView("SensorPartialViews/_ModifySelectedSensor", model);
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult ModifySelectedSensor(SensorDisplayData sensor)
        {
            var user = GetLoggedUsername();

            if (user != sensor.UserName)
            {
                throw new HttpException(403, "Unauthorized Access");
            }

            sensorDbService.ModifySpecificSesnor(sensor);

            return View("Success");
        }

        public async Task<ActionResult> UpdateSensorsValues()
        {
            //ICollection<{SensorIdICB}>
            IEnumerable<string> supportedSensors = await this.sensorApiService.ListSupportedSensorTypesFromAPI();

            //IDictionary<{SensorIdICB}, {MeasurementReadIn}>
            IDictionary<string, MeasurementReadIn> currentSensorsMeasurements = new Dictionary<string, MeasurementReadIn>();

            foreach (string SensorIdICB in supportedSensors)
            {
                MeasurementReadIn measurementICB = await this.sensorApiService.GetCurrentSensorValueFromAPI(SensorIdICB);

                //IDictionary<{SensorIdICB}, {MeasurementReadIn}>
                currentSensorsMeasurements.Add(SensorIdICB, measurementICB);
            }

            ICollection<Measurement> measurements = new List<Measurement>();

            IEnumerable<LastValueReadFromDbcs> allSensorsLastValues = this.sensorDbService.GetAllSensorsLastValues();

            //fuckin tested
            if (allSensorsLastValues.Count() != 0)
            {
                foreach (LastValueReadFromDbcs sensor in allSensorsLastValues)
                {
                    MeasurementReadIn measurementReadFromICB = currentSensorsMeasurements[sensor.SensorIdICB];

                    DateTime convertedDate = Convert.ToDateTime(measurementReadFromICB.TimeStamp);

                    DateTime checkDate = convertedDate.AddSeconds(10.0);

                    if (checkDate < DateTime.Now)
                    {
                        measurementReadFromICB.Value = "Sensor offline";
                    }

                    if (measurementReadFromICB.Value != sensor.Value)
                    {
                        Measurement measurement = new Measurement
                        {
                            SensorId = sensor.SensorId,
                            Date = convertedDate,
                            MeasurementType = measurementReadFromICB.ValueType,
                            Value = measurementReadFromICB.Value
                        };

                        //fuckin tested
                        measurements.Add(measurement);
                    }
                }

                //fuckin tested
                this.sensorDbService.AddNewMeasurementsToDb(measurements);
            }

            return this.View();
        }
        
        [HttpGet]
        [Authorize]
        public ActionResult InvalidInput(string message)
        {
            return this.View((object)message);
        }

        protected virtual string GetLoggedUsername()
        {
            return this.User.Identity.Name;
        }
    }
}