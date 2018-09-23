using System.Collections.Generic;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Contracts
{
    public interface ICommand
    {
        ITravellerFactory Factory { get; }

        IEngine Engine { get; }

        string Execute(IList<string> parameters);
    }
}
