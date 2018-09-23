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
    public class Train : Vehicle, ITrain
    {
        private int carts;

        public Train(int carts, int passangerCapacity, decimal pricePerKilometer, VehicleType type) : base(pricePerKilometer, type)
        {
            if ((passangerCapacity < Globals.trainMinPassengers && passangerCapacity > 0) || (passangerCapacity > Globals.trainMaxPassengers && passangerCapacity <= 800))
            {
                throw new ArgumentException
                    (Globals.InvalidPassengerNumber(Globals.trainMinPassengers, Globals.trainMaxPassengers,this.TypeOfVehicle()));
            }
            //else if (passangerCapacity <= 0 || passangerCapacity > 800)
            //{
            //    throw new ArgumentException(Globals.invalidVehiclePassengersCount);
            //}
            else
            {
                base.PassangerCapacity = passangerCapacity;
            }
            this.Carts = carts;
        }

        public int Carts
        {
            get
            {
                return this.carts;
            }
            set
            {
                if (value >= Globals.trainMinCarts && value <= Globals.trainMaxCarts)
                {
                    this.carts = value;
                }
                else
                {
                    throw new ArgumentException(Globals.invalidTrainCarts);
                }
            }
        }
        
        public override string TypeOfVehicle()
        {
            return "Train";
        }

        public override string ToString()
        {
            return string.Format("{0}\nCarts amount: {1}",
                base.ToString(),
                this.Carts);
        }
    }
}
