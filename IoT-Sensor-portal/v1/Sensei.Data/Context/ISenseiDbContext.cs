using Sensei.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Context
{
    public interface ISenseiDbContext
    {
        IDbSet<Sensor> Sensors { get; set; }

        IDbSet<Measurement> Measurement { get; set; }
    }
}
