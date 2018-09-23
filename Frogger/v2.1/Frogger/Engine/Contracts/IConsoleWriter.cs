using GameObjects;

namespace Engine
{
    public interface IConsoleWriter
    {
        void Render();
        void GameFreeze();
        void SetWindowDimentions();
        void ExitFrogger(string message);
        void WellcomeFrogger();
        void SelectGameSettings(IConsoleReader consoleReader);
    }
}
