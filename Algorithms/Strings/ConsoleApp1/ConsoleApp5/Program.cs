using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string text = Console.ReadLine();

            for (int i = 0; i <= text.Length - 1; i++)
            {
                Console.Write((char)text[i]);
            }
            for (int i = 0; i <=19-text.Length; i++)
            {
                Console.Write('*');
            }
        }
    }
}
