using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Data.Models;
using Sensei.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Context
{
    public class SenseiDbContext : IdentityDbContext<User>, ISenseiDbContext
    {
        public SenseiDbContext()
            : base("SenseiConnection")//throwIfV1Schema: false
        {
        }

        public IDbSet<Sensor> Sensors { get; set; }

        public IDbSet<Measurement> Measurement { get; set; }

        public static SenseiDbContext Create()
        {
            return new SenseiDbContext();
        }
    }
}
