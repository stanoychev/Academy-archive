using GameObjects;
using System;

namespace Engine
{
    public interface IModelFactory
    {
        IInfoRow CreateInfoRow(RowID rowID, IFrog frog);
        ISafeZoneRow CreateSafeZoneRow(RowID rowID, IFrog frog);
        ILaneRow CreateLaneRow(IVehicle vehicle, RowID rowID, IFrog frog);
        IVehicle CreateVehicle(Random randomizer);
    }
}