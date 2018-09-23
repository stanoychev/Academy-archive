using Traveller.Commands.Contracts;

namespace Traveller.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}