using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;
using Traveller.Utils;

namespace Traveller.Models
{
    public class Journey : IJourney
    {
        private string destination;
        private int distance;
        private string startLocation;
        private IVehicle vehicle;

        public Journey(string destination, int distance, string startLocation, IVehicle vehicle)
        {
            this.Destination = destination;
            this.Distance = distance;
            this.StartLocation = startLocation;
            this.Vehicle = vehicle;
        }

        public string Destination
        {
            get
            {
                return this.destination;
            }
            set
            {
                if (value.Length >= Globals.destinationsLengthMin && value.Length <= Globals.destinationsLengthMax)
                {
                    this.destination = value;
                }
                else
                {
                    throw new ArgumentException(Globals.InvalidLocationLength("Destination"));
                }
            }
        }

        public int Distance
        {
            get
            {
                return this.distance;
            }
            set
            {
                if (value >= Globals.distanceMin && value <= Globals.distanceMax)
                {
                    this.distance = value;
                }
                else
                {
                    throw new ArgumentException(Globals.invalidDistance);
                }
            }
        }

        public string StartLocation
        {
            get
            {
                return this.startLocation;
            }
            set
            {
                if (value.Length >= Globals.startLocationsLengthMin && value.Length <= Globals.startLocationsLengthMax)
                {
                    this.startLocation = value;
                }
                else
                {
                    throw new ArgumentException(Globals.InvalidLocationLength("StartingLocation"));
                }
            }
        }

        public IVehicle Vehicle
        {
            get
            {
                return this.vehicle;
            }
            set
            {
                this.vehicle = value;
            }
        }

        public decimal CalculateTravelCosts()
        {
            return this.distance * this.vehicle.PricePerKilometer;
        }

        public string TypeOfClass()
        {
            return "Journey";
        }

        public override string ToString()
        {
            return string.Format("{0} ----\nStart location: {1}\nDestination: {2}\nDistance: {3}\nVehicle type: {4}\nTravel costs: {5}",
                TypeOfClass(),
                this.startLocation,
                this.destination,
                this.distance,
                this.Vehicle.Type,
                CalculateTravelCosts());
        }
    }
}
