namespace GameObjects
{
    public interface ILaneRow : IRow
    {
        IVehicle VehicleOnTheRow { get; }
    }
}
