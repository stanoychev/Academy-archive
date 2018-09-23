using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Database;
using Sensei.Models.API;
using Sensei.Models.Database;
using Sensei.Models.View;
using Sensei.Services.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sensei.Controllers
{
    public class AutoSeedController : Controller
    {
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
        private readonly Random random;
        private readonly IDBService DBService;
        private readonly ApplicationDbContext dbContext;
        private readonly IAPIService APIService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SensorController sensorController;

        public AutoSeedController(IDBService DBService, ApplicationDbContext dbContext, IAPIService APIService, SensorController sensorController)
        {
            this.random = new Random();
            this.DBService = DBService ?? throw new ArgumentNullException("DbService in TestController");
            this.dbContext = dbContext ?? throw new ArgumentNullException("dbContext in TestController");
            this.APIService = APIService ?? throw new ArgumentNullException("sensorDataFetchingService in TestController");
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(dbContext));
            this.sensorController = sensorController;
        }

        public async Task<ActionResult> SeedUsers(int userCount = 5, int sensorsNumber = 5, int updatesNumber = 5, int delayerInSeconds = 5)
        {
            this.SeedUsers(userCount);
            await this.SeedSensors(sensorsNumber);
            await this.UpdateSensorsValues(updatesNumber, delayerInSeconds);
            return View();
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

        private void SeedUsers(int userCount = 5)
        {
            int trys = 0;
            for (int i = 0; i < userCount;)
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

        private async Task SeedSensors(int sensorsNumber = 5)
        {
            IDictionary<string, APISensorType> availableSensors = await this.APIService.ListSensorsFromAPI();

            //i v rega v sensor controlera

            this.DBService.UpdateSensorTypes(availableSensors);

            IList<string> supportedSensorTypes = availableSensors.Keys.ToList();

            IEnumerable<string> registeredUsers = this.DBService.ListAllUsers();

            bool inverse = true;

            foreach (string user in registeredUsers)
            {
                CustomSensorController customSensorController =
                new CustomSensorController(user, this.DBService, this.APIService);

                for (int i = 0; i < sensorsNumber; i++)
                {
                    inverse = !inverse;

                    APISensorType mainSensorInfo = availableSensors[supportedSensorTypes[this.random.Next(0, supportedSensorTypes.Count - 1)]];

                    string descriptionByICB = mainSensorInfo.Description;
                    string[] subDescription = descriptionByICB.Split(); //"This sensor will return values between 6 and 18" or "This sensor will return true or false value"

                    double minValue = 0;
                    double maxValue = 0;

                    if (subDescription.Contains("between"))
                    {
                        try //try with int
                        {
                            int mainMinValueI = int.Parse(subDescription[subDescription.Length - 3]);
                            int mainMaxValueI = int.Parse(subDescription[subDescription.Length - 1]);
                            int randomMinValue = this.random.Next(mainMinValueI, mainMaxValueI);
                            minValue = randomMinValue;
                            int randomMaxValue = this.random.Next(randomMinValue, mainMaxValueI);
                            maxValue = randomMaxValue;
                        }
                        catch
                        {
                            try //try with double. Trunkate because of Random() does not work with noninteger numbers
                            {
                                double mainMinValueD = Math.Truncate(double.Parse(subDescription[subDescription.Length - 3]));
                                double mainMaxValueD = Math.Truncate(double.Parse(subDescription[subDescription.Length - 1]));
                                int randomMinValue = this.random.Next((int)mainMinValueD, (int)mainMaxValueD);
                                minValue = randomMinValue;
                                int randomMaxValue = this.random.Next(randomMinValue, (int)mainMaxValueD);
                                maxValue = randomMaxValue;
                            }
                            catch //ebago
                            {
                            }
                        }
                    }

                    int pollingInterval = this.random.Next(mainSensorInfo.MinPollingIntervalInSeconds, mainSensorInfo.MinPollingIntervalInSeconds * 3);

                    RegisterNewSensor sensorModel = new RegisterNewSensor
                    {
                        AvailableSensors = null,
                        IsPublic = inverse,
                        PollingInterval = pollingInterval,
                        SensorIdICB = mainSensorInfo.SensorId,
                        Tag = mainSensorInfo.Tag,
                        UserDefinedSensorName = string.Format("{0}`s {1} sensor.", user, mainSensorInfo.Tag),
                        UserDefinedDescription = mainSensorInfo.Description,
                        UserDefinedMeasureType = mainSensorInfo.MeasureType, //to improove later
                        UserDefinedMinValue = minValue,
                        UserDefinedMaxValue = maxValue
                    };

                    customSensorController.RegisterNewSensor(sensorModel);
                }
            }
        }

        private async Task UpdateSensorsValues(int updatesNumber = 5, int delayerInSeconds = 5)
        {
            for (int i = 0; i < updatesNumber; i++)
            {
                Thread.Sleep(1000 * delayerInSeconds);

                await this.sensorController.UpdateSensorsValues();
            }
        }
    }

    public class CustomSensorController : SensorController
    {
        private string username;

        public CustomSensorController(string username, IDBService DBService, IAPIService APIService)
            : base(DBService, APIService)
        {
            this.username = username;
        }

        protected override string GetLoggedUsername()
        {
            return this.username;
        }
    }
}


