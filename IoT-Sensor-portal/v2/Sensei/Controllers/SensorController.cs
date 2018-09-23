using Sensei.Models.API;
using Sensei.Models.Database;
using Sensei.Models.Misc;
using Sensei.Models.View;
using Sensei.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Sensei.Controllers
{
    public class SensorController : Controller
    {
        private readonly IDBService DBService;
        private readonly IAPIService APIService;

        public SensorController(IDBService DBService, IAPIService APIService)
        {
            this.DBService = DBService ?? throw new ArgumentNullException("DbService in SensorController");
            this.APIService = APIService ?? throw new ArgumentNullException("sensorDataFetchingService in SensorController");
        }

        [OutputCache(Duration = 30)]
        public async Task<ActionResult> RenderChart(int sensorId)
        {
            var sensor = await DBService.GetSpecificSensorDisplayDataAsync(sensorId);

            if (!sensor.IsPublic)
            {
                if (GetLoggedUsername() != sensor.UserName)
                {
                    if (!DBService.BeingSharedWith(sensorId, GetLoggedUsername()))
                    {
                        throw new HttpException(403, "Access denied");
                    }
                }
            }

            var model = DBService.GetSensorHistory(sensor);

            return this.View("Charts/Chart", model);
        }

        public ActionResult ListAllPublicSensors()
        {
            IEnumerable<SensorDisplayData> publicSensors = this.DBService.ListPublicSensorsFromDB();

            return this.View(publicSensors);
        }

        public async Task<ActionResult> DeleteSensor(int sensorId)
        {
            var sensorData = await DBService.GetSpecificSensorDisplayDataAsync(sensorId);

            if (GetLoggedUsername() != sensorData.UserName)
            {
                throw new HttpException(403, "Access denied");
            }

            DBService.DeleteSensor(sensorId);

            return PartialView("SensorPartialViews/_Nothing");
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> RegisterNewSensor()
        {
            //IDictionary<{SensorIdICB}, SensorType>
            IDictionary<string, APISensorType> availableSensorsFromAPI = await this.APIService.ListSensorsFromAPI();
            this.DBService.UpdateSensorTypes(availableSensorsFromAPI);

            IEnumerable<APISensorType> availableSensors = availableSensorsFromAPI.Values;

            RegisterNewSensor sensorsFromApi = new RegisterNewSensor();
            sensorsFromApi.AvailableSensors = availableSensors;

            //to do later: check if sensors are no longer supported
            return this.View(sensorsFromApi);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult RegisterNewSensor(RegisterNewSensor sensorModel)
        {
            sensorModel.AvailableSensors = null; //just in case

            //validation
            if (!this.ModelState.IsValid)
            {
                return this.RedirectToAction("InvalidInput", new { message = "Invalid model state." });
            }

            if (sensorModel.SensorIdICB == null)
            {
                return this.RedirectToAction("InvalidInput", new { message = "Sensor ID cannot be empty." });
            }

            if (sensorModel.UserDefinedSensorName == null)
            {
                return this.RedirectToAction("InvalidInput", new { message = "Name cannot be empty." });
            }

            try
            {
                SensorType serverSensorType = this.DBService.GetSpecificSensorType(sensorModel.SensorIdICB);

                if (sensorModel.PollingInterval < serverSensorType.MinPollingIntervalInSeconds)
                {
                    return this.RedirectToAction("InvalidInput", new { message = "Invalid minimal polling interval." });
                }

                string operatingRange = serverSensorType.Description;
                string[] substring = operatingRange.Split();

                //"This sensor will return values between 6 and 18" or "This sensor will return true or false value"
                if (serverSensorType.IsNumericValue)
                {
                    //case sensor is integer type
                    double serverMinVal = double.Parse(substring[substring.Length - 3]);
                    double serverMaxVal = double.Parse(substring[substring.Length - 1]);

                    if (sensorModel.UserDefinedMinValue >= serverMinVal && sensorModel.UserDefinedMinValue <= serverMaxVal)
                    {
                    }
                    else
                    {
                        return this.RedirectToAction("InvalidInput", new { message = "Invalid sensor minimal value." });
                    }

                    if (sensorModel.UserDefinedMaxValue <= serverMaxVal && sensorModel.UserDefinedMaxValue >= serverMinVal)
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
                    if (sensorModel.UserDefinedMinValue != 0 || sensorModel.UserDefinedMaxValue != 0)
                    {
                        return this.RedirectToAction("InvalidInput", new { message = "Invalid sensor min / maximum value when the sensor is boolean type." });
                    }
                }

                //fix later with option the measurment type to be possible to be choosen and different
                sensorModel.UserDefinedMeasureType = serverSensorType.MeasureType;
            }
            catch
            {
                //this is if the user tries even entering invalid sensorIdICB just to brake the application
                return this.RedirectToAction("InvalidInput", new { message = "Invalid sensor ID." });
            }

            this.DBService
                .RegisterNewSensor(GetLoggedUsername(), sensorModel);

            return this.View("Success");
        }

        [Authorize]
        public ActionResult ListPersonalSensors()
        {
            string username = GetLoggedUsername();

            var model = this.DBService.ListOwnSensors(username);

            return this.View(model);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ShareSensor(int sensorId, string username)
        {
            try
            {
                DBService.ShareSensor(sensorId, username);
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
            IEnumerable<SensorDisplayData> ListSharedWithMeSensors = this.DBService.ListSharedWithMeSensors(this.User.Identity.Name);

            return this.View(ListSharedWithMeSensors);
        }

        [Authorize]
        public ActionResult ModifySensors()
        {
            var loggedUser = GetLoggedUsername();
            var model = DBService.ListOwnSensors(loggedUser).ToList();

            return this.View(model);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> ModifySelectedSensor(int sensorId)
        {
            var loggedUser = GetLoggedUsername();
            var model = await DBService.GetSpecificSensorDisplayDataAsync(sensorId);

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

            DBService.ModifySpecificSesnor(sensor);

            return View("Success");
        }

        public async Task<ActionResult> UpdateSensorsValues()
        {
            //ICollection<{SensorIdICB}>
            IEnumerable<string> supportedSensors = this.DBService.GetRegisteredSensorTypes(); //IEnumerable<string> supportedSensors = await this.APIService.ListSupportedSensorTypesFromAPI(); why the hell from api

            //IDictionary<{SensorIdICB}, {MeasurementReadIn}>
            IDictionary<string, APIMeasure> currentSensorsMeasures = new Dictionary<string, APIMeasure>();

            foreach (string SensorIdICB in supportedSensors)
            {
                APIMeasure measurementICB = await this.APIService.GetCurrentSensorValueFromAPI(SensorIdICB);

                DateTime convertedDate = Convert.ToDateTime(measurementICB.TimeStamp);

                DateTime checkDate = convertedDate.AddSeconds(10.0);

                if (checkDate < DateTime.Now)
                {
                    measurementICB.Value = "Sensor offline";
                }

                //IDictionary<{SensorIdICB}, {MeasurementReadIn}>
                currentSensorsMeasures.Add(SensorIdICB, measurementICB);
            }
            
            IEnumerable<LastValue> allSensorsLastValues = this.DBService.GetAllSensorsLastValues();

            if (allSensorsLastValues.Count() != 0)
            {
                ICollection<History> measurements = new List<History>();
                
                foreach (LastValue lastValue in allSensorsLastValues)
                {
                        APIMeasure currentMeasure = currentSensorsMeasures[lastValue.SensorIdICB];

                    if (currentMeasure.Value != lastValue.Value)
                    {
                        History measurement = new History
                        {
                            SensorId = lastValue.SensorId,
                            From = lastValue.From,
                            To = DateTime.Now,
                            Value = currentMeasure.Value
                        };

                        measurements.Add(measurement);
                    }
                }

                this.DBService.AddNewMeasurementsToDb(measurements);
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