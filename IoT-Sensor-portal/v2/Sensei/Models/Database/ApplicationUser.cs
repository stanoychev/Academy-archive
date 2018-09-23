using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Sensei.Models.Database
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        private ICollection<Sensor> ownedSensors;
        private ICollection<Sensor> sensorsSharedWithMe;

        public ApplicationUser()
        {
            this.ownedSensors = new HashSet<Sensor>();
            this.sensorsSharedWithMe = new HashSet<Sensor>();
        }

        public virtual ICollection<Sensor> OwnedSensors
        {
            get
            {
                return this.ownedSensors;
            }
            set
            {
                this.ownedSensors = value;
            }
        }

        public virtual ICollection<Sensor> SharedWithMe
        {
            get
            {
                return this.sensorsSharedWithMe;
            }
            set
            {
                this.sensorsSharedWithMe = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}