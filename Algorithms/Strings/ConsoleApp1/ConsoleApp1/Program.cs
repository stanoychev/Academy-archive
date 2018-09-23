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
            string input = Console.ReadLine();

            PrintString(ReverseString(input));
        }
        public static string ReverseString(string input)
        {
            char[] temp = new char[input.Length];
            for (int i = 0; i <= input.Length-1; i++)
            {
                temp[i] = input[input.Length - 1-i];
            }
            return new string(temp);
        }
        public static void PrintString(string input)
        {
            for (int i = 0; i <=input.Length-1; i++)
            {
                Console.Write(input[i]);
            }
        }
    }
}
