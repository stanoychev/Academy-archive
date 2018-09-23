using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Contracts.DatabaseContexts;
using Sensei.Models;

namespace Sensei.Seeders
{
    public class AdminSeeder : Seeder
    {
        private UserManager<ApplicationUser> userManager;

        public AdminSeeder(ApplicationDbContext appDbCtx) : base(appDbCtx)
        {
            this.userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(appDbCtx));
        }

        public override void Seed()
        {
            if (!base.appDbCtx.Users.Any(u => u.UserName == "Xadera"))
            {
                var admin = new ApplicationUser
                {
                    UserName = "Xadera",
                    Email = "ragnarokha@gmail.com"
                };

                var password = "@dministrat0R";

                userManager.Create(admin, password);
                userManager.AddToRoles(admin.Id, new[] {"Admin", "User"});
            }
        }
    }
}