using Traveller.Models.Enums;

namespace Traveller.Models.Vehicles.Contracts
{
    public interface IVehicle
    {
        int PassangerCapacity { get; set; }

        decimal PricePerKilometer { get; set; }

        // Please, please, please implement me
        VehicleType Type { get; set; }
    }
}