namespace Traveller.Models.Vehicles.Contracts
{
    public interface IAirplane : IVehicle
    {
        bool HasFreeFood { get; set; }
    }
}