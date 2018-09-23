using Bytes2you.Validation;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace Traveller.Commands.Creating
{
    public class ListTicketsCommand : ListingCommands, IListingCommands
    {
        private readonly IDatabase database;

        public ListTicketsCommand(IDatabase database) : base(database)
        {
        }

        protected override string ListTypeAsString()
        {
            return "tickets";
        }
    }
}
