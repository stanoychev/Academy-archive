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

            ArrayAscendingSorter(array); //sorting the array

            string toDisplay = ArraySeparator(array); //displaying the array

            Console.WriteLine(toDisplay);
        }
        public static void ArrayMaker(string input, int[] array)
            {
            string[] subString = input.Split(' ');
            for (int i = 0; i <=subString.GetLength(0)-1; i++)
            {
                array[i] = int.Parse(subString[i]);
            }
            } //raboti
        public static void ArrayAscendingSorter(int[] array)
        {
            int[] tempArray = new int[array.GetLength(0)];
            bool[] boolArray = new bool[array.GetLength(0)]; //default false
            int[] minMax = new int[2]; //{ min value , max value }
            int a = 0;
            int b = array.GetLength(0) - 1;
            
            while (a<=b)
            {
                GetMin(array, boolArray, minMax);
                GetMax(array, boolArray, minMax);
                tempArray[a] = minMax[0];
                tempArray[b] = minMax[1];
                a++;
                b--;
            }
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                array[i] = tempArray[i];
            }
        }
        public static void GetMax(int[] array, bool[] boolArray, int[] minMax)
        {
            minMax[1] = array[0];
            int indexOfMaxNum = 0;
            for (int i = 1; i <= array.GetLength(0)- 1 ; i++)
            {
                if (array[i] > minMax[1] && boolArray[i] == false)
                {
                    minMax[1] = array[i];
                    indexOfMaxNum = i;
                }
            }
            boolArray[indexOfMaxNum] = true;
        }
        public static void GetMin(int[] array, bool[] boolArray, int[] minMax)
        {
            minMax[0] = array[0];
            int indexOfMinNum = 0;
            for (int i = 1; i <= array.GetLength(0) - 1; i++)
            {
                if (array[i] < minMax[0] && boolArray[i] == false)
                {
                    minMax[0] = array[i];
                    indexOfMinNum = i;
                }
            }
            boolArray[indexOfMinNum] = true;
        }
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