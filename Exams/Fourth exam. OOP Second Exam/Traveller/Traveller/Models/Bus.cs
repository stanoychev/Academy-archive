using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Abstract;
using Traveller.Models.Enums;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Utils;

namespace Traveller.Models
{
    public class Bus : Vehicle, IBus
    {
        public Bus(int passangerCapacity, decimal pricePerKilometer, VehicleType type) : base(pricePerKilometer, type)
        {
            if ((passangerCapacity<Globals.busMinPassengers && passangerCapacity>0) || (passangerCapacity>Globals.busMaxPassengers && passangerCapacity<=800))
            {
                throw new ArgumentException(Globals.InvalidPassengerNumber(Globals.busMinPassengers, Globals.busMaxPassengers,this.TypeOfVehicle()));
            }
            //else if (passangerCapacity<=0 || passangerCapacity>800)
            //{
            //    throw new ArgumentException(Globals.invalidVehiclePassengersCount);
            //}
            else
            {
                base.PassangerCapacity = passangerCapacity;
            }
        }

        public override string TypeOfVehicle()
        {
            return "Bus";
        }
        
    }
}
