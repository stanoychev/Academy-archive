namespace GameObjects
{
    public interface IInfoRow : IRow
    {
        int GameSpeed { set; }

        int GameScore { set; }
    }
}