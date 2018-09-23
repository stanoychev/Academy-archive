using Online_Store.Commands;

namespace Online_Store.Core.Factories
{
    public interface ICommandFactory
    {
        ICommand CreateCommand(string commandName);
    }
}
