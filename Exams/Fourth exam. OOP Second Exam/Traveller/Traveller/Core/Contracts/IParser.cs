using Traveller.Commands.Contracts;
using System.Collections.Generic;

namespace Traveller.Core.Contracts
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);

        IList<string> ParseParameters(string fullCommand);
    }
}
