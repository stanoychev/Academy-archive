using Bytes2you.Validation;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : ListingCommands, IListingCommands
    {
        private readonly IDatabase database;

        public ListJourneysCommand(IDatabase database) : base(database)
        {
        }

        protected override string ListTypeAsString()
        {
            return "journeys";
        }
    }
}
