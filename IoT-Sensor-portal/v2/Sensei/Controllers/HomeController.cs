using Sensei.Database;
using Sensei.Models.View;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sensei.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationUserManager userManager;
        private ApplicationDbContext appDbContext;

        public HomeController(ApplicationUserManager userManager, ApplicationDbContext appDbContext)
        {
            this.userManager = userManager;
            this.appDbContext = appDbContext;
        }

        [OutputCache(Duration = 10)]
        public async  Task<ActionResult> Index()
        {
            var model = new StatsViewModel
            {
                UsersCount = await userManager.Users.CountAsync(),
                SensorsCount = await appDbContext.Sensors.CountAsync(),
                PublicSensorsCount = await appDbContext.Sensors.CountAsync(x => x.IsPublic),
                PrivateSensorsCount = await appDbContext.Sensors.CountAsync(x => !x.IsPublic)
            };

            return this.View(model);
        }

        [OutputCache(Duration = 10)]
        public ActionResult About()
        {
            return this.View();
        }
    }
}