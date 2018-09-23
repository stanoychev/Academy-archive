using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Abstract;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public abstract class CreateVehicleCommand : Command
    {
        public CreateVehicleCommand(ITravellerFactory factory, IEngine engine) : base(factory, engine)
        {
        }

        public override string ToString()
        {
            return string.Format("Vehicle with ID {0} was created.", base.Engine.Vehicles.Count - 1);
        }
    }
}
