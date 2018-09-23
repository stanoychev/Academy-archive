using GameObjects;

namespace Engine
{
    public interface IConsoleReader
    {
        void UpdateFrogPosition(IFrog frog, ISettings settings);
        void SelectGameDificulty(ISettings settings);
        void SelectVideoMode(ISettings settings);
    }
}