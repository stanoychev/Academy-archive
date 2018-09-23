using System.Data.Entity.Migrations;
using System.Linq;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Sensei.Data.Context
{
    public class Configuration : DbMigrationsConfiguration<SenseiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(SenseiDbContext context)
        {
            ////if no users are present in the database, Admin is created
            //if(!context.Roles.Any())
            //{
            //    var role = context.Roles.Add(new IdentityRole("Admin"));
                
            //    role = context.Roles.Single();
            //    var user = context.Users.Single();
            //    user.Roles.Add(new IdentityUserRole()
            //    {
            //        RoleId = role.Id,
            //        UserId = user.Id
            //    });
            //}
        }
    }
}