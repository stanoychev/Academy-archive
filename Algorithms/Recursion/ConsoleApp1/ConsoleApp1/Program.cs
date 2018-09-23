using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            Reverce(input, input.Length-1, output);
            Console.WriteLine(output.ToString());
        }
        public static void Reverce (string input, int i, StringBuilder output)
        {
            if (i == -1)
            {
            }
            else
            {
                output.Append(input[i]);
                Reverce(input, i - 1, output);
            }
        }
    }
}
