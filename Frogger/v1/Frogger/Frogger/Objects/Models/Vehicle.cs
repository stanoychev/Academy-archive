using Frogger.Objects.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Frogger.Objects.Models
{
    public class Vehicle : Subject, IVehicle
    {
        private int speed;
        private string direction;
        private int vehicleLength;

        public Vehicle()
        {
        }

        public int Speed
        {
            get
            {
                return this.speed;
            }
            set
            {
                this.speed = value;
            }
        }

        public string Direction
        {
            get
            {
                return this.direction;
            }
            set
            {
                this.direction = value;
            }
        }

        public int VehicleLength
        {
            get
            {
                return this.vehicleLength;
            }
            set
            {
                this.vehicleLength = value;
            }
        }

        public override string ToString()
        {
            return string.Format("__{0}__*  {1}  *-@{2}@-",
                new string('_', 2 * this.vehicleLength),
                string.Concat(Enumerable.Repeat("[]", this.vehicleLength)),
                string.Concat(Enumerable.Repeat("--", this.vehicleLength)));
        }
    }
}
