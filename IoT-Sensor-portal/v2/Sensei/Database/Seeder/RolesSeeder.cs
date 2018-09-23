using Microsoft.AspNet.Identity.EntityFramework;
using System.Linq;

namespace Sensei.Database.Seeder
{
    public class RolesSeeder : Seeder
    {

        public RolesSeeder(ApplicationDbContext appApplicationDbContext) : base(appApplicationDbContext) { }

        public override void Seed()
        {
            if (!base.appApplicationDbContext.Roles.Any(r => r.Name == "Admin"))
            {
                base.appApplicationDbContext.Roles.Add(new IdentityRole("Admin"));
            }

            if (!base.appApplicationDbContext.Roles.Any(r => r.Name == "User"))
            {
                base.appApplicationDbContext.Roles.Add(new IdentityRole("User"));
            }

            base.appApplicationDbContext.SaveChangesAsync();
        }
    }
}