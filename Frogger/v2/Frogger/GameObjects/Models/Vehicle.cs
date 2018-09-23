using System;
using System.Linq;
using Utils;

namespace GameObjects
{
    public class Vehicle : IVehicle
    {
        private int x;
        private int vehicleSpeed;
        //private VehicleDirection direction;
        private int vehicleFillMultiplier;

        public Vehicle(Random randomizer)
        {
            this.x =randomizer.Next(GlobalConstants.vehicleMinX, GlobalConstants.vehicleMaxX);
            this.VehicleSpeed = randomizer.Next(GlobalConstants.vehicleMinSpeed, GlobalConstants.vehicleMaxSpeed);
            this.VehicleFillMultiplier = randomizer.Next(GlobalConstants.vehicleFillMultiplierMin, GlobalConstants.vehicleFillMultiplierMax);
        }
        
        public int X
        {
            get
            {
                //if (this.x >= 0)
                //{
                    return this.x;
                //}
                //else
                //{
                //    return GlobalConstants.vehicleMinX;
                //}
            }
            set
            {
                if (value >= GlobalConstants.vehicleMinX && value <= GlobalConstants.vehicleMaxX)
                {
                    this.x = value;
                }
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
        
        //public void UpdateVehiclePosition()
        //{
        //    if (this.x + this.VehicleSpeed + ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed
        //        >=
        //        GlobalConstants.vehicleMaxX)
        //    {
        //        this.VehicleSpeed = randomizer.Next(GlobalConstants.vehicleMinSpeed, GlobalConstants.vehicleMaxSpeed);
        //        this.VehicleFillMultiplier = randomizer.Next(GlobalConstants.vehicleFillMultiplierMin, GlobalConstants.vehicleFillMultiplierMax);
        //        this.x = 0;
        //    }
        //    else
        //    {
        //        this.x += this.VehicleSpeed + ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed;
        //    }
        //}
        
        public override string ToString()
        {
            return string.Format("__{0}__*  {1}  *-@{2}@-",
                new string('_', 2 * this.vehicleFillMultiplier),
                string.Concat(Enumerable.Repeat("[]", this.vehicleFillMultiplier)),
                string.Concat(Enumerable.Repeat("--", this.vehicleFillMultiplier)));
        }
    }
}
