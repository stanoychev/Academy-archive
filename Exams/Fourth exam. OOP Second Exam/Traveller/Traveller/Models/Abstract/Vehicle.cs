using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Enums;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Utils;

namespace Traveller.Models.Abstract
{
    public class Vehicle : IVehicle
    {
        private int passangerCapacity;
        private decimal pricePerKilometer;
        private VehicleType type;

        public Vehicle(decimal pricePerKilometer, VehicleType type)
        {
            this.PricePerKilometer = pricePerKilometer;
            this.Type = type;
        }

        public int PassangerCapacity
        {
            get
            {
                return this.passangerCapacity;
            }
            set
            {
                if (value >= Globals.vehicleMinPassengers && value <= Globals.vehicleMaxPassengers)
                {
                    this.passangerCapacity = value;
                }
                else
                {
                    throw new ArgumentException(Globals.invalidVehiclePassengersCount);
                }
            }
        }
        public decimal PricePerKilometer
        {
            get
            {
                return this.pricePerKilometer;
            }
            set
            {
                if (value >= Globals.vehicleMinPrice && value <= Globals.vehicleMaxPrice)
                {
                    this.pricePerKilometer = value;
                }
                else
                {
                    throw new ArgumentException(Globals.invalidVehiclePricePerKilometer);
                }
            }
        }
        public VehicleType Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }

        public virtual string TypeOfVehicle()
        {
            return "vehicle";
        }

        public override string ToString()
        {
            return string.Format("{0} ----\nPassenger capacity: {1}\nPrice per kilometer: {2}\nVehicle type: {3}",
                TypeOfVehicle(),
                this.PassangerCapacity,
                this.pricePerKilometer,
                this.type.ToString());
        }
    }
}
