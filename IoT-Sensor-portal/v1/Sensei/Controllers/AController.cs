using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Contracts.DatabaseContexts;
using Sensei.Data.DbService;
using Sensei.Data.Models;
using Sensei.Data.Models.Intermediate;
using Sensei.Database.DbContext;
using Sensei.Database.Models;
using Sensei.Database.Models.Measurement_IO_models;
using Sensei.Models;
using Sensei.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sensei.Controllers
{
    public class AController : Controller
    {
        private readonly Random random;
        private readonly ISensorDbService sensorDbService;
        private readonly IApplicationDbContext dbContext;
        private readonly ISensorApiService sensorApiService;
        private readonly UserManager<ApplicationUser> userManager;

        public AController(ISensorDbService sensorDbService,
                                ApplicationDbContext dbContext,
                                ISensorApiService sensorApiService
            )
        {
            this.random = new Random();
            this.sensorDbService = sensorDbService ?? throw new ArgumentNullException("DbService in TestController");
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext in TestController");
            this.sensorApiService = sensorApiService ?? throw new ArgumentNullException("sensorDataFetchingService in TestController");
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
        }

        public async Task<ActionResult> X()
        {
            this.SeedStamat();
            await this.SeedStamatSensors();

            return View();
        }

        public async Task<ActionResult> A()
        {
            this.SeedUsers();
            await this.SeedSensors();
            await this.SeedMeasurements();
            
            return View();
        }

        public async Task<ActionResult> Z()
        {
            await this.SeedMeasurements();

            return View();
        }

        private void SeedStamat()
        {
            string username = "stamat";

            if (!this.dbContext.Users.Any(u => u.UserName == username))
            {
                var newUser = new ApplicationUser
                {
                    UserName = username,
                    Email = $"{username}@gmail.com"
                };

                string password = username;

                this.userManager.Create(newUser, password);
                this.userManager.AddToRoles(newUser.Id, new[] { "User" });
            }
        }

        private async Task SeedStamatSensors()
        {
            IDictionary<string, SensorReadInData> availableSensors = await this.sensorApiService.ListSensorsFromAPI();

            this.sensorDbService.UpdateSensorTypes(availableSensors);

            IList<string> supportedSensorTypes = availableSensors.Keys.ToList();

            string user = "stamat";

            bool inverse = true;

            for (int i = 0; i < 10; i++)
            {
                inverse = !inverse;

                SensorReadInData coreSensorInfo = availableSensors[supportedSensorTypes[this.random.Next(0, supportedSensorTypes.Count - 1)]];

                string descriptionByICB = coreSensorInfo.Description;
                string[] subDescription = descriptionByICB.Split(); //"This sensor will return values between 6 and 18" or "This sensor will return true or false value"

                double minValue = 0;
                double maxValue = 0;

                if (subDescription.Contains("between"))
                {
                    try //try with int
                    {
                        int minValueI = int.Parse(subDescription[subDescription.Length - 3]);
                        int randomMinValue = this.random.Next(minValueI, 3 * minValueI);
                        minValue = randomMinValue;

                        int maxValueI = int.Parse(subDescription[subDescription.Length - 1]);
                        int randomMaxValue = this.random.Next(maxValueI, 3 * maxValueI);
                        maxValue = randomMaxValue;
                    }
                    catch
                    {
                        try //try with double
                        {
                            double minValueD = Math.Truncate(double.Parse(subDescription[subDescription.Length - 3]));
                            int randomMinValue = this.random.Next((int)minValueD, 3 * (int)minValueD);
                            minValue = randomMinValue;

                            double maxValueD = Math.Truncate(double.Parse(subDescription[subDescription.Length - 1]));
                            int randomMaxValue = this.random.Next((int)maxValueD, 3 * (int)maxValueD);
                            maxValue = randomMaxValue;
                        }
                        catch //ebago
                        {
                        }
                    }
                }

                SensorType sensorType = new SensorType
                {
                    SensorIdICB = coreSensorInfo.SensorId,
                    Tag = coreSensorInfo.Tag,
                    MinPollingIntervalInSeconds = coreSensorInfo.MinPollingIntervalInSeconds,
                    MeasureType = coreSensorInfo.MeasureType
                };

                int pollingInterval = this.random.Next(coreSensorInfo.MinPollingIntervalInSeconds, coreSensorInfo.MinPollingIntervalInSeconds * 3);
                
                Sensor newSensor = new Sensor
                {
                    Name = string.Format("{0}`s {1} sensor.", user, coreSensorInfo.Tag),
                    DescriptionGivenByTheUser = coreSensorInfo.Description,
                    MeasurementType = coreSensorInfo.MeasureType,
                    IsPublic = inverse,
                    OperatingRange = coreSensorInfo.Description,
                    MinValue = minValue,
                    MaxValue = maxValue,
                    LastValue = new LastValue
                    {
                        SensorIdICB = coreSensorInfo.SensorId,
                        PollingInterval = pollingInterval
                    }
                };

                this.sensorDbService.RegisterNewSensor(user, newSensor);
            }

        }

        //private async Task<ActionResult> Clear()
        //{
        //    //to implement

        //    return View();
        //}

        //private async Task<ActionResult> FeedMany()
        //{
        //    //to implement

        //    return View();
        //}

        private void SeedUsers()
        {
            int trys = 0;
            for (int i = 0; i < 10;)
            {
                if (this.dbContext.Users.Count() >= 20)
                {
                    return;
                }

                string username = this.usernameBank[this.random.Next(0, this.usernameBank.Length - 1)];

                if (!this.dbContext.Users.Any(u => u.UserName == username))
                {
                    var newUser = new ApplicationUser
                    {
                        UserName = username,
                        Email = $"{username}@gmail.com"
                    };

                    string password = username;

                    this.userManager.Create(newUser, password);
                    try
                    {
                        this.userManager.AddToRoles(newUser.Id, new[] { "User" });
                        i++;
                    }
                    catch
                    {
                    }
                }
                else
                {
                    trys++;
                }

                if (trys == 10)
                {
                    return;
                }
            }
        }

        private async Task SeedSensors()
        {
            IDictionary<string, SensorReadInData> availableSensors = await this.sensorApiService.ListSensorsFromAPI();

            //i v rega v sensor controlera

            //samo se dobavqt novi ako ima, ako nqkoi iska da se vizualizira ne6to deto go nqma => not syupoorted animore
            this.sensorDbService.UpdateSensorTypes(availableSensors);

            IList<string> supportedSensorTypes = availableSensors.Keys.ToList();

            IEnumerable<string> registeredUsers = this.sensorDbService.ListAllUsers();

            bool inverse = true;

            foreach (string user in registeredUsers)
            {
                for (int i = 0; i < 10; i++)
                {
                    inverse = !inverse;

                    SensorReadInData coreSensorInfo = availableSensors[supportedSensorTypes[this.random.Next(0, supportedSensorTypes.Count - 1)]];

                    string descriptionByICB = coreSensorInfo.Description;
                    string[] subDescription = descriptionByICB.Split(); //"This sensor will return values between 6 and 18" or "This sensor will return true or false value"

                    double minValue = 0;
                    double maxValue = 0;

                    if (subDescription.Contains("between"))
                    {
                        try //try with int
                        {
                            int minValueI = int.Parse(subDescription[subDescription.Length - 3]);
                            int randomMinValue = this.random.Next(minValueI, 3 * minValueI);
                            minValue = randomMinValue;

                            int maxValueI = int.Parse(subDescription[subDescription.Length - 1]);
                            int randomMaxValue = this.random.Next(maxValueI, 3 * maxValueI);
                            maxValue = randomMaxValue;
                        }
                        catch
                        {
                            try //try with double
                            {
                                double minValueD = Math.Truncate(double.Parse(subDescription[subDescription.Length - 3]));
                                int randomMinValue = this.random.Next((int)minValueD, 3 * (int)minValueD);
                                minValue = randomMinValue;

                                double maxValueD = Math.Truncate(double.Parse(subDescription[subDescription.Length - 1]));
                                int randomMaxValue = this.random.Next((int)maxValueD, 3 * (int)maxValueD);
                                maxValue = randomMaxValue;
                            }
                            catch //ebago
                            {
                            }
                        }
                    }

                    SensorType sensorType = new SensorType
                    {
                        SensorIdICB = coreSensorInfo.SensorId,
                        Tag = coreSensorInfo.Tag,
                        MinPollingIntervalInSeconds = coreSensorInfo.MinPollingIntervalInSeconds,
                        MeasureType = coreSensorInfo.MeasureType
                    };

                    int pollingInterval = this.random.Next(coreSensorInfo.MinPollingIntervalInSeconds, coreSensorInfo.MinPollingIntervalInSeconds * 3);
                    
                    Sensor newSensor = new Sensor
                    {
                        Name = string.Format("{0}`s {1} sensor.", user, coreSensorInfo.Tag),
                        DescriptionGivenByTheUser = coreSensorInfo.Description,
                        MeasurementType = coreSensorInfo.MeasureType,
                        IsPublic = inverse,
                        OperatingRange = coreSensorInfo.Description,
                        MinValue = minValue,
                        MaxValue = maxValue,
                        LastValue = new LastValue
                        {
                            SensorIdICB = coreSensorInfo.SensorId,
                            PollingInterval = pollingInterval
                        }
                    };

                    this.sensorDbService.RegisterNewSensor(user, newSensor);
                }
            }
        }

        private async Task SeedMeasurements()
        {
            IDictionary<string, MeasurementReadIn> currentSensorsMeasurements = new Dictionary<string, MeasurementReadIn>();
            ICollection<Measurement> measurements = new List<Measurement>();
            IEnumerable<LastValueReadFromDbcs> allSensors = new List<LastValueReadFromDbcs>();

            IEnumerable<string> supportedSensors = await this.sensorApiService.ListSupportedSensorTypesFromAPI();

            //te tuka e proverkata za no longer supported, dori pak da dojde, da si regne nov

            foreach (string SensorIdICB in supportedSensors)
            {
                MeasurementReadIn measurementICB = await this.sensorApiService.GetCurrentSensorValueFromAPI(SensorIdICB);

                currentSensorsMeasurements.Add(SensorIdICB, measurementICB);
            }

            for (int i = 0; i < 10; i++)
            {
                allSensors = this.sensorDbService.GetAllSensorsLastValues();

                if (allSensors.Count() != 0)
                {
                    foreach (LastValueReadFromDbcs sensor in allSensors)
                    {
                        MeasurementReadIn measurementReadFromICB = currentSensorsMeasurements[sensor.SensorIdICB];

                        if (measurementReadFromICB.Value != sensor.Value)
                        {
                            DateTime convertedDate = Convert.ToDateTime(measurementReadFromICB.TimeStamp);

                            Measurement measurement = new Measurement()
                            {
                                SensorId = sensor.SensorId,
                                Date = convertedDate,
                                MeasurementType = measurementReadFromICB.ValueType,
                                Value = measurementReadFromICB.Value
                            };

                            measurements.Add(measurement);
                        }
                    }

                    this.sensorDbService.AddNewMeasurementsToDb(measurements);
                }

                Thread.Sleep(5000); //5 sec
            }
        }

        private readonly string[] usernameBank = new[]
        {
            "KyX^naPa3uT",              "nu4a_c_KocaTa",        "Дай_пет_лева",             "KoTka_uguoTka",
            "KuceJlo_MJleko",           "MyTpa_C_TpuOH",        "MopkoB",                   "MaHgapuHka",
            "CnopmeH_Tpakmop",          "Kyxa_neuKa",           "Qm_Vinkel",                "AZ_TUP_LI_SAM",
            "Pero_maglata",             "serien_samoubiec",     "Slepiq_sniper",            "/\\yD_CaM_MaMo_QM_napkeT",
            "bonus_frag4e",             "XanBaM_nApKeT",        "bAhura",                   "KpaCtaBu4aP",
            "MaPuHoBaHa_KpaCTaBu4ka",   "nOTeH_Mo3aK",          "Ma3Ha_5aHu4ka",            "neETapDaSiLesno",
            "pushi_mi_se",              "Prasenceto_Go6ko",     "Me4o_nyX_e_r/\\yX",        "Me4o_nyX_e_kyX",
            "Killvam_i_byrzo_begam",    "Zelio_Zelev_Zeleto",   "onq_s_kitarata",           "K()KAL",
            "kOlEgI_az_SYM",            "kIRo_zaVar4ika",       "TaLaSaMa",                 "LeKaR_S_No6",
            "A3uC",                     "Starshinkata",         "6e_si_kupia_reis",         "ne_strelqi_mamo_az_s1m",
            "isteriqta_Megz",           "Pen4o_KuCoTo_MaGaRe",  "Babati_ena_5ti_kolovoz",   "Lamqta_Spaska",
            "MaMa_Mpa3u_XaKePu",        "BossaNaBossa",         "Bossa",                    "me4o_pux",
            "Karlos_4akala",            "[SM]uKoHoCTaCa",       "CecoTelebabisa",           "DjaPankA",
            "osama_bil_gladen",         "mirc_gangster",        "maniaka_cs",               "strelqm_ot_prozoreca",
            "prepe4ena_pala4inka",      "kiofte",               "begai_be_ka6ona_e_zaet",   "kacnu4aHcka_kepeMuga",
            "npace B kocMoca",          "iastreba",             "MuchSkunkyMovie",          "aL_Ka6on3",
            "makaron udu6va4",          "yMpu-y-neCbk",         "Govedo_na_roleri",         " Pa3gPaHu_BeHu",
            "Pesho-testoto",            "Veso_Pesa",            "Dobrata_Shmatka",          "Go6o tapoto",
            "ГОСПОД®",                  "Bastun",               "ZelenChuk",                "pepi_kva_e_taq_bira_ma",
            "meka_kifli4ka",            "zul_kosmodisk",        "ma4o_pi4a",                "Brainless",
            "Pulnen`trup`s`zele",       "Rozovo_dupe",          "TUPOTOmace",               "ebasimo",
            "PauPaH_TaPukaT",           "TyXJla^4eTBopKa",      "KyX^naPa3uT",              "Rapyr_s_vratovryzka ",
            "Djihada",                  "pastet ",              "Mityo_gryn4a",             "Borko_Tpena4a ",
            "Sur_pi4uk",                "Tzura",                "Anichka-Banichka",         "Traveller",
            "Stamat",                   "Pesho",                "Munio",                    "Penka"
        };
    }
}


