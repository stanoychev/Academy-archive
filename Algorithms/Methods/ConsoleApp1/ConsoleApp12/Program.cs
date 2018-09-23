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
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n]; //create empty global array
            string toArrayAndSort = Console.ReadLine();

            ArrayMaker(toArrayAndSort, array); //string to array

            Array.Sort(array); //sorting the array

            string toDisplay = ArraySeparator(array); //displaying the array

            Console.WriteLine(toDisplay);
        }
        public static void ArrayMaker(string input, int[] array)
        {
            string[] subString = input.Split(' ');
            for (int i = 0; i <= subString.GetLength(0) - 1; i++)
            {
                array[i] = int.Parse(subString[i]);
            }
        } //raboti
        public static string ArraySeparator(int[] separateMe)
        {
            StringBuilder done = new StringBuilder();

            for (int i = 0; i <= separateMe.GetLength(0) - 1; i++)
            {
                done.Append(separateMe[i]);
                if (i != separateMe.GetLength(0) - 1) done.Append(' ');
            }

            return (string)done.ToString();
        }  //raboti
    }
}