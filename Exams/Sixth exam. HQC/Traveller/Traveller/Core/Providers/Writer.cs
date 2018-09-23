using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Traveller.Core.Providers
{
    public class Writer : IWriter
    {
        public void Write(string text)
        {
            Console.Write(text);
        }
    }
}
