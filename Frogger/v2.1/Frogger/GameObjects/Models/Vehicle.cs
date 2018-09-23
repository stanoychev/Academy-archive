using Engine;
using System;
using System.Linq;

namespace GameObjects
{
    public class Vehicle : IVehicle
    {
        private int x;
        private int vehicleSpeed;
        //private VehicleDirection direction;
        private int vehicleFillMultiplier;
        private ISettings settings;

        public Vehicle(Random randomizer, ISettings settings)
        {
            this.settings = settings;
            if (this.settings.GameReadyToStart)
            {
                this.x = randomizer.Next(this.settings.VehicleMinX, this.settings.VehicleMaxX(this.VehicleDisplayLength));
            }
            else throw new ArgumentException("Vehicle constructor: Game not ready to start!");
            this.VehicleSpeed = randomizer.Next(this.settings.VehicleMinSpeed, this.settings.VehicleMaxSpeed);
            this.VehicleFillMultiplier = randomizer.Next(this.settings.VehicleFillMultiplierMin, this.settings.VehicleFillMultiplierMax);
        }
        
        public int X
        {
            get
            {
                return this.x;
            }
            set
            {
                if (this.settings.GameReadyToStart)
                {
                    if (value >= this.settings.VehicleMinX && value <= this.settings.VehicleMaxX(this.VehicleDisplayLength))
                    {
                        this.x = value;
                    }
                }
                else throw new ArgumentException("Game not ready to start!");
            }
        }

        public int VehicleSpeed
        {
            get
            {
                return this.vehicleSpeed;
            }
            set
            {
                if (value>0)
                {
                    this.vehicleSpeed = value;
                }
            }
        }

        //public VehicleDirection Direction { get; set; }

        public int VehicleFillMultiplier
        {
            get
            {
                return this.vehicleFillMultiplier;
            }
            set
            {
                this.vehicleFillMultiplier = value;
            }
        }

        public int VehicleDisplayLength
        {
            get
            {
                return this.ToString().Split('*')[0].Length;
            }
        }
        
        public int VehicleEndX
        {
            get
            {
                return this.x + this.VehicleDisplayLength - 1;
            }
        }
        
        public override string ToString()
        {
            return string.Format("__{0}__*  {1}  *-@{2}@-",
                new string('_', 2 * this.vehicleFillMultiplier),
                string.Concat(Enumerable.Repeat("[]", this.vehicleFillMultiplier)),
                string.Concat(Enumerable.Repeat("--", this.vehicleFillMultiplier)));
        }
    }
}
