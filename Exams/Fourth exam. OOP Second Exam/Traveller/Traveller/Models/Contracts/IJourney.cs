using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Models.Contracts
{
    public interface IJourney
    {
        string Destination { get; }

        int Distance { get; }

        string StartLocation { get;}

        IVehicle Vehicle { get; }

        decimal CalculateTravelCosts();
    }
}