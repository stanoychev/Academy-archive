using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Contracts.DatabaseContexts;
using Sensei.Data.Models;
using Sensei.Database.Models;
using Sensei.Models;
using System.Data.Entity;

namespace Sensei.Database.DbContext
{

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>, IApplicationDbContext
    {
        public ApplicationDbContext()
            : base("SenseiDB", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Sensor> Sensors { get; set; }
        public virtual IDbSet<Measurement> Measurements { get; set; }
        public virtual IDbSet<LastValue> LastValues { get; set; }
        public virtual IDbSet<SensorType> SensorTypes { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.SharedWithMe)
                .WithMany(s => s.SharedWith);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.OwnedSensors)
                .WithRequired(s => s.ApplicationUser);

            modelBuilder.Entity<Sensor>()
               .HasMany(s => s.Measurements)
               .WithRequired(m => m.Sensor)
               .HasForeignKey(m => m.SensorId);
        }
    }
}