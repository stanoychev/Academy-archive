using Bytes2you.Validation;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace Traveller.Commands.Creating
{
    public class ListVehiclesCommand : ListingCommands, IListingCommands
    {
        private readonly IDatabase database;

        public ListVehiclesCommand(IDatabase database) : base(database)
        {
        }

        protected override string ListTypeAsString()
        {
            return "vehicles";
        }
    }
}
