namespace Engine
{
    public interface IEngine
    {
        bool TestConditions { set; }
        int GameSpeed { get; set; }
        int GameScore { get; }
        void Load();
        void Run();
    }
}