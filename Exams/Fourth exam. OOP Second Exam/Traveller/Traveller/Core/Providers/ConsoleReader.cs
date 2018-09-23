using Traveller.Core.Contracts;
using System;

namespace Traveller.Core.Providers
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
