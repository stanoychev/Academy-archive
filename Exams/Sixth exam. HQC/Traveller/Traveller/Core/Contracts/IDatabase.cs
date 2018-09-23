using System.Collections.Generic;
using Traveller.Models.Abstractions;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Core
{
    public interface IDatabase
    {
        IList<IVehicle> Vehicles { get; }
        
        IList<IJourney> Journeys { get; }

        IList<ITicket> Tickets { get; }
    }
}