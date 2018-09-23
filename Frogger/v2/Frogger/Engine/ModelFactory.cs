using GameObjects;
using Ninject;
using System;

namespace Engine
{
    public class ModelFactory : IModelFactory
    {
        public IInfoRow CreateInfoRow(RowID rowID, IFrog frog)
        {
            return new InfoRow(rowID, frog);
        }
        
        public ISafeZoneRow CreateSafeZoneRow(RowID rowID, IFrog frog)
        {
            return new SafeZoneRow(rowID, frog);
        }

        public ILaneRow CreateLaneRow(IVehicle vehicle, RowID rowID, IFrog frog)
        {
            return new LaneRow(vehicle, rowID, frog);
        }

        public IVehicle CreateVehicle(Random randomizer)
        {
            return new Vehicle(randomizer);
        }
    }
}
