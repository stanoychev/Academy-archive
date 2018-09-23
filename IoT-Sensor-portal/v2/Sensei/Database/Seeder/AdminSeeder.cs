using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Models.Database;
using System.Linq;

namespace Sensei.Database.Seeder
{
    public class AdminSeeder : Seeder
    {
        private UserManager<ApplicationUser> userManager;

        public AdminSeeder(ApplicationDbContext appApplicationDbContext) : base(appApplicationDbContext)
        {
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(appApplicationDbContext));
        }

        public override void Seed()
        {
            string adminUsername = "admin";
            string adminPassword = "admin1";//
            string adminEmail = "admin@admin.com";

            if (!base.appApplicationDbContext.Users.Any(u => u.UserName == adminUsername))
            {
                var admin = new ApplicationUser
                {
                    UserName = adminUsername,
                    Email = adminEmail
                };

                var password = adminPassword;

                userManager.Create(admin, password);
                userManager.AddToRoles(admin.Id, new[] { "Admin", "User" });
            }
        }
    }
}