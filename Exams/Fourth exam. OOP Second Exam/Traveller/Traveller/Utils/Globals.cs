using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveller.Utils
{
    public static class Globals
    {
        public const int trainMinPassengers = 30;
        public const int trainMaxPassengers = 150;
        public const int trainMinCarts = 1;
        public const int trainMaxCarts = 15;
        public const int busMinPassengers = 10;
        public const int busMaxPassengers = 50;
        public const int vehicleMinPassengers = 1;
        public const int vehicleMaxPassengers = 800;
        public const decimal vehicleMinPrice = 0.10m;
        public const decimal vehicleMaxPrice = 2.50m;
        public const int startLocationsLengthMin = 5;
        public const int startLocationsLengthMax = 25;
        public const int destinationsLengthMin = 5;
        public const int destinationsLengthMax = 25;
        public const int distanceMin = 5;
        public const int distanceMax = 5000;

        //if there is enough time combine with the constants above
        public const string invalidTrainCarts = "Specified argument was out of the range of valid values.\nParameter name: A train cannot have less than 1 cart or more than 15 carts.";
        public const string invalidDistance = "Specified argument was out of the range of valid values.\nParameter name: The Distance cannot be less than 5 or more than 5000 kilometers.";
        //public const string invalidVehiclePassengersCount = "A vehicle with less than 1 passengers or more than 800 passengers cannot exist!";
        public const string invalidVehiclePassengersCount = "Specified argument was out of the range of valid values.\nParameter name: A vehicle with less than 1 passengers or more than 800 passengers cannot exist!";
        public const string invalidVehiclePricePerKilometer = "Specified argument was out of the range of valid values.\nParameter name: A vehicle with a price per kilometer lower than $0.10 or higher than $2.50 cannot exist!";
        
        public static string InvalidPassengerNumber(int min, int max, string type)
        {
            //type must be "train" or "bus", if BGCoder does not pass, try adding "airplane" also
            return string.Format("Specified argument was out of the range of valid values.\nParameter name: A {0} cannot have less than {1} passengers or more than {2} passengers.", type.ToLower(), min, max);
        }
        
        public static string InvalidLocationLength(string type, int min = 5, int max = 25)
        {
            //type == "StartingLocation" or type == "Destination"
            return string.Format("Specified argument was out of the range of valid values.\nParameter name: The {0}'s length cannot be less than {1} or more than {2} symbols long.", type, min, max);
        }
    }
}
