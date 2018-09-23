using Sensei.Database;
using Sensei.Models.View;
using Sensei.Services.Contracts;
using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Sensei.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationUserManager userManager;
        private IDBService DBService;

        public AdminController(ApplicationUserManager userManager, ApplicationDbContext appDbContext, IDBService DBService)
        {
            this.userManager = userManager;
            this.DBService = DBService;
        }

        [Authorize(Roles = "Admin")]
        public async Task<ViewResult> Users()
        {
            var model = new List<UsersViewModel>();

            foreach (var user in await userManager.Users.ToListAsync())
            {
                var roles = await userManager.GetRolesAsync(user.Id);
                model.Add(new UsersViewModel
                {
                    User = user,
                    Role = roles.Contains("Admin") ? "Admin" : "User"
                });
            }

            return View(model);
        }


        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> Sensors()
        {
            List<SensorDisplayData> model = await DBService.ListAllSensorsAsync();

            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public ActionResult DeleteSensor(int sensorId)
        {
            DBService.DeleteSensor(sensorId);

            return PartialView("AdminPartialViews/_Nothing");
        }

        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> ToggleRole(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            var roles = await userManager.GetRolesAsync(user.Id);
            string role;


            if (roles.Contains("Admin"))
            {
                await userManager.RemoveFromRoleAsync(userId, "Admin");
                role = "User";
            }
            else
            {
                await userManager.AddToRoleAsync(userId, "Admin");
                role = "Admin";
            }

            var model = new UsersViewModel
            {
                User = user,
                Role = role
            };

            return PartialView("AdminPartialViews/_Toggle", model);
        }

    }
}
