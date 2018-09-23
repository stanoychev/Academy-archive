using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Contracts;
using Traveller.Core;

namespace Traveller.Commands
{
    public abstract class ListingCommands : IListingCommands
    {
        private readonly IDatabase database;

        public ListingCommands(IDatabase database)
        {
            Guard.WhenArgument(database, "Database in the listing command cannot be null.").IsNull().Throw();

            this.database = database;
        }

        protected virtual string ListTypeAsString()
        {
            return "base";
        }

        public string Execute()
        {
            IEnumerable<Object> list;
            
            switch (ListTypeAsString())
            {
                case "journeys": list = this.database.Journeys; break;
                case "tickets": list = this.database.Tickets; break;
                default: list = this.database.Vehicles; break;
            }

            if (list.Count() == 0)
            {
                return string.Format("There are no registered {0}.", ListTypeAsString());
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, list);
        }
    }
}
