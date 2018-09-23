using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string reverseMe = Console.ReadLine();
            Console.WriteLine(ReverseString(reverseMe));
        }
        public static string ReverseString(string reverseMe)
        {
            char[] CharArray = new char[reverseMe.Length];
            for (int i = 0; i <= reverseMe.Length - 1; i++)
            {
                CharArray[i] = reverseMe[reverseMe.Length - 1 - i];
            }
            return new string(CharArray);
        }
    }
}