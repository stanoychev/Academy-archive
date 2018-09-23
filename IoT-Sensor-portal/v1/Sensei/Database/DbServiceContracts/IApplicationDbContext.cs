using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Data.Models;
using Sensei.Database.Models;
using Sensei.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Threading;
using System.Threading.Tasks;
using Sensei.Data.Models.Intermediate;

namespace Sensei.Contracts.DatabaseContexts
{
    public interface IApplicationDbContext
    {
        IDbSet<ApplicationUser> Users { get; set; }
        IDbSet<IdentityRole> Roles { get; set; }
        IDbSet<Sensor> Sensors { get; set; }
        IDbSet<Measurement> Measurements { get; set; }
        IDbSet<LastValue> LastValues { get; set; }
        IDbSet<SensorType> SensorTypes { get; set; }

        bool RequireUniqueEmail { get; set; }
        DbChangeTracker ChangeTracker { get; }
        DbContextConfiguration Configuration { get; }
        DbSet Set(Type entityType);
        int SaveChanges();
        Task<int> SaveChangesAsync();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        IEnumerable<DbEntityValidationResult> GetValidationErrors();
        DbEntityEntry Entry(object entity);
        void Dispose();
        string ToString();
        bool Equals(object obj);
        int GetHashCode();
        Type GetType();
    }
}
