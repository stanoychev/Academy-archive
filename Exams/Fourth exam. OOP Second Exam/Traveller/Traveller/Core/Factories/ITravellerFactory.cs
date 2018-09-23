using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Core.Contracts
{
    public interface ITravellerFactory
    {
        IBus CreateBus(int passengerCapacity, decimal pricePerKilometer);
        
        ITrain CreateTrain(int passengerCapacity, decimal pricePerKilometer, int carts);

        IAirplane CreateAirplane(int passengerCapacity, decimal pricePerKilometer, bool hasFreeFood);

        IJourney CreateJourney(string startingLocation, string destination, int distance, IVehicle vehicle);

        ITicket CreateTicket(IJourney journey, decimal administrativeCosts);


    }
}
