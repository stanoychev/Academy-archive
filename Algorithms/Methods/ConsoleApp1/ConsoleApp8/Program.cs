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
            Console.ReadLine();
            string toCleanAndReverce1 = Console.ReadLine();
            string toCleanAndReverce2 = Console.ReadLine();

            string toReverse1 = SpaceClean(toCleanAndReverce1);
            string toReverse2 = SpaceClean(toCleanAndReverce2);

            string toSum1 = ReverseString(toReverse1);
            string toSum2 = ReverseString(toReverse2);

            string toReverse = SumStrings(toSum1, toSum2);
            
            string toSeparate = (toReverse);

            string toDisplay = SeparateString(toSeparate);

            Console.WriteLine(toDisplay);
        }
        public static string SpaceClean(string cleanMe)
        {
            List<char> done = new List<char>();
            
            for (int i = 0; i <= cleanMe.Length - 1; i++)
            {
                if (cleanMe[i] != ' ') done.Add(cleanMe[i]);
            }

            return new string (done.ToArray());
        }
        public static string ReverseString(string reverseMe)
        {
            char[] done= new char[reverseMe.Length];
            for (int i = 0; i <= reverseMe.Length - 1; i++)
            {
                done[i] = reverseMe[reverseMe.Length - 1 - i];
            }
            return new string(done);
        }
        public static string SeparateString(string num)
        {
            List<char> done = new List<char>();
            for (int i = 0; i <= num.Length - 1; i++)
            {
                done.Add(num[i]);
                if (i < num.Length - 1)
                {
                    done.Add(' ');
                }
            }
            return new string(done.ToArray());
        }
        public static string SumStrings(string num1, string num2)
        {
            short smallerNum = 0;
            short biggerNum = 0;
            if (num1.Length < num2.Length)
            {
                smallerNum = (short)num1.Length;
                biggerNum = (short)num2.Length;
            }
            else
            {
                smallerNum = (short)num2.Length;
                biggerNum = (short)num1.Length;
            }
            List<char> done = new List<char>();
            byte naum = 0;
            byte value1 = 0;
            byte value2 = 0;

            for (short i = 0; i<= biggerNum - 1;i++)
            {
                if (i<= smallerNum-1)
                {
                    value1 = (byte)(num1[num1.Length-1-(int)i]-48);
                    value2 = (byte)(num2[num2.Length-1-i]-48);
                    done.Add((char)(48+((value1 + value2 + naum) % 10)));
                    naum = (byte)((value1 + value2 + naum) / 10);
                }
                else
                {
                    if (num1.Length > num2.Length)
                    {
                        value1 = (byte)(num1[num1.Length - 1 - i]-48);
                    }
                    else
                    {
                        value1 = (byte)(num2[num2.Length - 1 - i]-48);
                    }
                    done.Add((char)(48+((value1 + naum) % 10)));
                    naum = (byte)((value1 + naum) / 10);
                }
                if (i==biggerNum-1 && naum==1)
                {
                    done.Add((char)49);
                }
            }
            return new string(done.ToArray());
        }
    }
}