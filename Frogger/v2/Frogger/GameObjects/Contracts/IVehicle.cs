namespace GameObjects
{
    public interface IVehicle
    {
        int X { get; set; }
        int VehicleSpeed { get; set; }
        //VehicleDirection Direction { get; set; }
        int VehicleFillMultiplier { get; set; }
        int VehicleDisplayLength { get; }
        int VehicleEndX { get; }
    }
}
