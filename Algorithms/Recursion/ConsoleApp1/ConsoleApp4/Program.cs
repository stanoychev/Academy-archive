using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            Console.WriteLine(Reverce(input));
        }
        public static string Reverce(string input)
        {
            if (input.Length == 1)
            {
                return input;
            }
            else
            {
                input.Remove(input.Length - 1);
                return input + Reverce(input);
            }
        }
    }
}
