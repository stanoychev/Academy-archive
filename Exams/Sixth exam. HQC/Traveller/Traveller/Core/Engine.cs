using System;
using System.Collections.Generic;
using System.Text;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Core.Providers;

namespace Traveller.Core
{
    public class Engine : IEngine
    {
        private const string TerminationCommand = "Exit";
        private const string NullProvidersExceptionMessage = "cannot be null.";
        
        private StringBuilder Builder = new StringBuilder();

        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IParser parser;
        private readonly ITravellerFactory database;
        private readonly ITravellerFactory travellerFactory;
        private readonly ICommandFactory commandFactory;

        public Engine(IReader reader, IWriter writer, IParser parser,
            ITravellerFactory database, ITravellerFactory travellerFactory, ICommandFactory commandFactory)
        {
            this.reader = reader ?? throw new ArgumentNullException("Reader in engine cannot be null.");
            this.writer = writer ?? throw new ArgumentNullException("Writer in engine cannot be null.");
            this.parser = parser ?? throw new ArgumentNullException("Parser in engine cannot be null.");
            this.database = database ?? throw new ArgumentNullException("Database in engine cannot be null.");
            this.travellerFactory = travellerFactory ?? throw new ArgumentNullException("TravellerFactory in engine cannot be null.");
            this.commandFactory = commandFactory ?? throw new ArgumentNullException("Command factory in engine cannot be null.");
        }
        
        public void Start()
        {
            while (true)
            {
                try
                {
                    var commandAsString = this.reader.ReadLine() ?? throw new ArgumentNullException("Command cannot be null or empty.");

                    if (commandAsString.ToLower() == TerminationCommand.ToLower())
                    {
                        this.writer.Write(this.Builder.ToString());
                        break;
                    }

                    this.ProcessCommand(commandAsString);
                }
                catch (Exception ex)
                {
                    this.Builder.AppendLine(ex.Message);
                }
            }
        }

        private void ProcessCommand(string commandAsString)
        {
            ICommand command = this.parser.ParseCommand(commandAsString,this.commandFactory) ?? throw new ArgumentNullException("Object command cannot be null.");
            IList<string> parameters = parser.ParseParameters(commandAsString) ?? throw new ArgumentNullException("List cannot be null.");

            string executionResult = command.Execute(parameters);
            this.Builder.AppendLine(executionResult);
        }
    }
}
