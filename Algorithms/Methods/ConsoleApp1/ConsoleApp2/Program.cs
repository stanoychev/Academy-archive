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
            string input = Console.ReadLine();
            string[] nums = input.Split(' ');
            
            Console.WriteLine(GetMax(GetMax(int.Parse(nums[0]), int.Parse(nums[1])), int.Parse(nums[2])));
        }
        public static int GetMax(int a, int b)
            {
            if (a > b) return a;
            else return b;
            }
    }
}