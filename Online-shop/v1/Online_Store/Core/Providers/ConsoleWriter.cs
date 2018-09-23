using System;

namespace Online_Store.Core.Providers
{
    public class ConsoleWriter : IWriter
    {
        public void CleanScrean()
        {
            Console.Clear();
        }

        public void Write(string text)
        {
            Console.Write(text);
        }

        public void WriteLine(string text)
        {
            Console.WriteLine(text);
        }
    }
}
