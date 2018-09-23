namespace Engine
{
    public interface IEngine
    {
        void Run(IModelFactory modelFactory, IConsoleReader consoleReader);
    }
}