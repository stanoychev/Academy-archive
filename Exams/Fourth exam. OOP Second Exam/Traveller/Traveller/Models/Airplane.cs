using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Abstract;
using Traveller.Models.Enums;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models
{
    public class Airplane : Vehicle, IAirplane
    {
        private bool hasFreeFood;

        public Airplane(bool hasFreeFood, int passangerCapacity, decimal pricePerKilometer, VehicleType type) : base(pricePerKilometer, type)
        {
            base.PassangerCapacity = passangerCapacity;
            this.HasFreeFood = hasFreeFood;
        }

        public bool HasFreeFood
        {
            get
            {
                return this.hasFreeFood;
            }
            set
            {
                this.hasFreeFood = value;
            }
        }

        public override string TypeOfVehicle()
        {
            return "Airplane";
        }

        public override string ToString()
        {
            string freeFood;
            if (this.hasFreeFood)
            {
                freeFood = "True";
            }
            else
            {
                freeFood = "False";
            }
            //if there is enough time do it by capitalizing firstLetter
            return string.Format("{0}\nHas free food: {1}",
                base.ToString(),
                freeFood);
        }
    }
}
