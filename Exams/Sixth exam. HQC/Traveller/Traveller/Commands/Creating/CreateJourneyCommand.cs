using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Models.Vehicles.Abstractions;

namespace Traveller.Commands.Creating
{
    public class CreateJourneyCommand : ICommand
    {
        private readonly IDatabase database;
        private readonly ITravellerFactory travellerFactory;

        public CreateJourneyCommand(IDatabase database, ITravellerFactory travellerFactory)
        {
            Guard.WhenArgument(database, "Database in create journey command cannot be null.").IsNull().Throw();
            Guard.WhenArgument(travellerFactory, "The factory, that creates commands, in create journey command cannot be null.").IsNull().Throw();

            this.database = database;
            this.travellerFactory = travellerFactory;
        }

        public string Execute(IList<string> parameters)
        {
            Guard.WhenArgument(parameters, "Parameters list in create journey command cannot be null.").IsNull().Throw();

            string startLocation;
            string destination;
            int distance;
            IVehicle vehicle;

            try
            {
                startLocation = parameters[0];
                destination = parameters[1];
                distance = int.Parse(parameters[2]);
                vehicle = this.database.Vehicles[int.Parse(parameters[3])];
            }
            catch
            {
                throw new ArgumentException("Failed to parse CreateJourney command parameters.");
            }

            var journey = this.travellerFactory.CreateJourney(startLocation, destination, distance, vehicle);
            this.database.Journeys.Add(journey);

            return $"Journey with ID {this.database.Journeys.Count - 1} was created.";
        }
    }
}
