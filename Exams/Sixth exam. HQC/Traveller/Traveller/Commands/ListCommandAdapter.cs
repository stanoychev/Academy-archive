using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;

namespace Traveller.Commands
{
    public class ListCommandAdapter : ICommand
    {
        private readonly IListingCommands listingCommands;

        public ListCommandAdapter(IListingCommands listingCommands)
        {
            this.listingCommands = listingCommands ?? throw new ArgumentNullException();
        }

        public string Execute(IList<string> parameters)
        {
            return this.listingCommands.Execute();
        }
    }
}
