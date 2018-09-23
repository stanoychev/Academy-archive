using Bytes2you.Validation;
using System.Collections.Generic;
using System.Linq;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Core.Providers
{
    public class CommandParser : IParser
    {
        public ICommand ParseCommand(string fullCommand, ICommandFactory commandFactory)
        {
            Guard.WhenArgument(commandFactory, "Command factory in command parser cannot be null.").IsNull().Throw();
            Guard.WhenArgument(fullCommand, "Command`s name cannot be null or empty.").IsNullOrEmpty().Throw();
            string commandName = fullCommand.Split()[0];
            return commandFactory.CreateCommand(commandName);
        }

        public IList<string> ParseParameters(string fullCommand)
        {
            Guard.WhenArgument(fullCommand, "Command`s name cannot be null or empty.").IsNullOrEmpty().Throw();
            List<string> commandParts = fullCommand.Split().Skip(1).ToList();
            if (commandParts.Count == 0)
            {
                return new List<string>();
            }

            return commandParts;
        }
    }
}
