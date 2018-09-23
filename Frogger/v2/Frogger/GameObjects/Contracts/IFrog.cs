namespace GameObjects
{
    public interface IFrog
    {
        int X { get; set; }
        int Row { get; set; }
        int Lives { get; set; }
        bool IsAlive { get; }
        int FrogLevel { get; set; }
        int FrogDisplayLength { get; }
        int FrogEndX { get; }
    }
}
