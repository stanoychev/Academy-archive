using System.Collections.Generic;
using Traveller.Core;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Contracts
{
    public interface ICommand
    {
        string Execute(IList<string> parameters);
    }
}
