using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Database.DbContext;
using System.Linq;

namespace Sensei.Seeders
{
    public class RolesSeeder : Seeder
    {

        public RolesSeeder(ApplicationDbContext appDbCtx) : base(appDbCtx) { }

        public override void Seed()
        {
            if (!base.appDbCtx.Roles.Any(r => r.Name == "Admin"))
            {
                base.appDbCtx.Roles.Add(new IdentityRole("Admin"));
            }

            if (!base.appDbCtx.Roles.Any(r => r.Name == "User"))
            {
                base.appDbCtx.Roles.Add(new IdentityRole("User"));
            }

            base.appDbCtx.SaveChangesAsync();
        }
    }
}