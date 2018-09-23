using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
                Console.ReadLine();
                string toCleanAndReverce1 = Console.ReadLine();
                string toCleanAndReverce2 = Console.ReadLine();

                string toReverse1 = SpaceClean(toCleanAndReverce1);
                string toReverse2 = SpaceClean(toCleanAndReverce2);

                int toSum1 = int.Parse(ReverseString(toReverse1));
                int toSum2 = int.Parse(ReverseString(toReverse2));
                int sum = toSum1 + toSum2;
                Console.WriteLine(ReverseString(SeparateString(sum)));
        }
        public static string SpaceClean(string cleanMe)
        {
            StringBuilder done = new StringBuilder();
            for (int i = 0; i < cleanMe.Length; i++)
            {
                if (cleanMe[i]!=' ') done.Append(cleanMe[i]);
            }
            return done.ToString();
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
        public static string SeparateString(int num)
        {
            StringBuilder done = new StringBuilder();
            for (int i = 0; i <=num.ToString().Length-1; i++)
            {
                done.Append(num.ToString()[i]);
                if (i < num.ToString().Length - 1)
                {
                    done.Append(' ');
                }
            }
            return done.ToString();
        }
    }   
}