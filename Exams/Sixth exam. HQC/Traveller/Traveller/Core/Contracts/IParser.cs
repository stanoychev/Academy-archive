using System.Collections.Generic;
using Traveller.Commands.Contracts;
using Traveller.Core.Factories;

namespace Traveller.Core
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand, ICommandFactory commandFactory);

        IList<string> ParseParameters(string fullCommand);
    }
}