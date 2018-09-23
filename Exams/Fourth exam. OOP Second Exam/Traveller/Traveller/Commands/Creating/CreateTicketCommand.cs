using System;
using System.Collections.Generic;
using Traveller.Commands.Abstract;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Models.Contracts;
using Traveller.Models.Vehicles.Contracts;

namespace Traveller.Commands.Creating
{
    public class CreateTicketCommand : Command
    {
        public CreateTicketCommand(ITravellerFactory factory, IEngine engine) : base(factory,engine)
        {
        }
        
        public override string Execute(IList<string> parameters)
        {
            decimal administrativeCosts;
            IJourney journey;

            try
            {
                administrativeCosts = decimal.Parse(parameters[1]);
                journey = base.Engine.Journeys[int.Parse(parameters[0])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateTicket command parameters.");
            }

            var ticket = base.Factory.CreateTicket(journey,administrativeCosts);

            base.Engine.Tickets.Add(ticket);

            return $"Ticket with ID {base.Engine.Tickets.Count - 1} was created.";
        }
    }
}
