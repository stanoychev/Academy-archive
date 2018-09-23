using Frogger.Objects.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger
{
    public interface IVehicle : ISubject

    {
        int Speed { get; set; }
        string Direction { get; set; }
        int VehicleLength { get; set; }
    }
}
