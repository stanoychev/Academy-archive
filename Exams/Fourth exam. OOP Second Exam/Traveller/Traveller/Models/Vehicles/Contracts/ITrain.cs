using Traveller.Models.Enums;

namespace Traveller.Models.Vehicles.Contracts
{
    public interface ITrain : IVehicle
    {
        int Carts { get; set; }
    }
}