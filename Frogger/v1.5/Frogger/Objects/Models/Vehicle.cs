using Frogger.Objects.Abstract;
using Frogger.Renderer;
using Frogger.Renderer.Abstract;
using Frogger.Renderer.Enums;
using Frogger.Renderer.Models;
using Frogger.Renderer.RowCollection;
using Frogger.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Models
{
    public class Vehicle : Subject, IVehicle
    {
        private static Random randomizer = new Random();
        private int vehicleSpeed;
        //private string direction;
        private int vehicleFillMultiplier;

        public Vehicle() : base()
        {
            //When created the vehicle will be with random length on a random position with a random speed
            base.X =randomizer.Next(GlobalConstants.vehicleMinX, GlobalConstants.vehicleMaxX);
            this.VehicleSpeed = randomizer.Next(GlobalConstants.vehicleMinSpeed, GlobalConstants.vehicleMaxSpeed);
            this.VehicleFillMultiplier = randomizer.Next(GlobalConstants.vehicleFillMultiplierMin, GlobalConstants.vehicleFillMultiplierMax);
        }
        
        private int X
        {
            get
            {
                if (base.X >= 0)
                {
                    return base.X;
                }
                else
                {
                    return GlobalConstants.vehicleMinX;
                }
            }
            set
            {
                if (value >= GlobalConstants.vehicleMinX && value <= GlobalConstants.vehicleMaxX)
                {
                    base.X = value;
                }
            }
        }

        public int Row
        {
            get
            {
                return base.Row;
            }
            set
            {
                if (IsVehicleOnAnAowedRow(value))
                {
                    base.Row = value;
                }
            }
        }

        public int VehicleSpeed
        {
            get
            {
                return this.vehicleSpeed;
            }
            private set
            {
                if (value>0)
                {
                    this.vehicleSpeed = value;
                }
            }
        }

        //public string Direction
        //{
        //    get
        //    {
        //        return this.direction;
        //    }
        //    set
        //    {
        //        this.direction = value;
        //    }
        //}

        public int VehicleFillMultiplier
        {
            get
            {
                return this.vehicleFillMultiplier;
            }
            private set
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
                return base.X + this.VehicleDisplayLength - 1;
            }
        }

        private bool IsVehicleOnAnAowedRow(int row)
        {
            //for further development
            //this can be elegantly resolved  using the reflection technique, something currently I know nothing about
            return ((row >= (int)RowID.Second && row <= (int)RowID.Seventh)
                    ||
                    (row >= (int)RowID.Ninth && row <= (int)RowID.Fourteenth));
        }

        public void UpdateVehiclePosition()
        {
            if (base.X + this.VehicleSpeed + ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed
                >=
                GlobalConstants.vehicleMaxX)
            {
                this.VehicleSpeed = randomizer.Next(GlobalConstants.vehicleMinSpeed, GlobalConstants.vehicleMaxSpeed);
                this.VehicleFillMultiplier = randomizer.Next(GlobalConstants.vehicleFillMultiplierMin, GlobalConstants.vehicleFillMultiplierMax);
                base.X = 0;
            }
            else
            {
                base.X += this.VehicleSpeed + ((BaseRow)RowCollection.Instance.Rows.ElementAt(0)).GameSpeed;
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
