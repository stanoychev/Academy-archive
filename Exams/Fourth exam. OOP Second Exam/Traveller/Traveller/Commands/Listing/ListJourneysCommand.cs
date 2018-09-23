using System;
using System.Collections.Generic;
using Traveller.Commands.Abstract;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Creating
{
    public class ListJourneysCommand : Command
    {
        public ListJourneysCommand(ITravellerFactory factory, IEngine engine):base(factory,engine)
        {
        }

        public override string Execute(IList<string> parameters)
        {
            var journeys = base.Engine.Journeys;

            if (journeys.Count == 0)
            {
                return "There are no registered journeys.";
            }

            return string.Join(Environment.NewLine + "####################" + Environment.NewLine, journeys);
        }
    }
}
