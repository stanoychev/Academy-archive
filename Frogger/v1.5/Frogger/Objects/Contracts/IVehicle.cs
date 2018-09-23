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
        int VehicleSpeed { get; }
        //string Direction { get; set; }
        int VehicleFillMultiplier { get; }
        int VehicleDisplayLength { get; }
        int VehicleEndX { get; }
    }
}
