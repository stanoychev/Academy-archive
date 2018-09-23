using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder output = new StringBuilder();
            Reverce(input, output);
            Console.WriteLine(output.ToString());
        }
        public static void Reverce(string input, StringBuilder output)
        {
            if (input.Length==1)
            {
            }
            else
            {
                input.Remove(input.Length-1);
                Reverce(input, output);
                output.Append(input);
            }
        }
    }
}
