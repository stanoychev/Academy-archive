using GameObjects;
using System;

namespace Engine
{
    public interface IModelFactory
    {
        IInfoRow CreateInfoRow(IFrog frog, int rowID);
        ISafeZoneRow CreateSafeZoneRow(IFrog frog, int rowID, ISettings settings);
        ILaneRow CreateLaneRow(IVehicle vehicle, IFrog frog, int rowID, ISettings settings);
        IVehicle CreateVehicle(Random randomizer, ISettings settings);
    }
}