using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory travellerFactory;

        public CreateTicketCommand(IDatabase database, ITravellerFactory travellerFactory)
        {
            Guard.WhenArgument(database, "Database in create ticket command cannot be null.").IsNull().Throw();
            Guard.WhenArgument(travellerFactory, "The factory, that creates commands, in create ticket command cannot be null.").IsNull().Throw();

            this.database = database;
            this.travellerFactory = travellerFactory;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "Parameters list in create ticket command cannot be null.").IsNull().Throw();

            IJourney journey;
            decimal administrativeCosts;

            try
            {
                int journeyID = int.Parse(parameters[0]);
                foreach (var item in parameters[1])
                {
                    if (item==',')
                    {
                        throw new ArgumentException();
                    }
                }
                if (journeyID < 0 || decimal.Parse(parameters[1]) < 0)
                {
                    throw new ArgumentException();
                }
                journey = this.database.Journeys[journeyID];
                administrativeCosts = decimal.Parse(parameters[1]);
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = this.travellerFactory.CreateTicket(journey, administrativeCosts);
            this.database.Tickets.Add(ticket);

            return $"Ticket with ID {this.database.Tickets.Count - 1} was created.";
        }
    }
}
