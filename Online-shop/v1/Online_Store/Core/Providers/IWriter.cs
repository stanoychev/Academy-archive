namespace Online_Store.Core.Providers
{
    public interface IWriter
    {
        void Write(string text);

        void WriteLine(string text);

        void CleanScrean();
    }
}
