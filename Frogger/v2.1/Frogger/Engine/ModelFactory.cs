using GameObjects;
using System;

namespace Engine
{
    public class ModelFactory : IModelFactory
    {
        public IInfoRow CreateInfoRow(IFrog frog, int rowID)
        {
            return new InfoRow(frog, rowID);
        }
        
        public ISafeZoneRow CreateSafeZoneRow(IFrog frog, int rowID, ISettings settings)
        {
            return new SafeZoneRow(frog, rowID, settings);
        }

        public ILaneRow CreateLaneRow(IVehicle vehicle, IFrog frog, int rowID, ISettings settings)
        {
            return new LaneRow(vehicle, frog, rowID, settings);
        }

        public IVehicle CreateVehicle(Random randomizer, ISettings settings)
        {
            return new Vehicle(randomizer, settings);
        }
    }
}
