using Online_Store.Commands;

namespace Online_Store.Core.Providers
{
    public interface IParser
    {
        ICommand ParseCommand(string fullCommand);
    }
}
