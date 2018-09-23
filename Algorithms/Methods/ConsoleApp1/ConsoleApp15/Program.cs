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
            short n = short.Parse(Console.ReadLine());
            short[] array = new short[n]; //create empty global array
            string toArrayAndSort = Console.ReadLine();

            ArrayMaker(toArrayAndSort, array); //string to array

            ArrayAscendingSorter(array); //sorting the array

            string toDisplay = ArraySeparator(array); //displaying the array

            Console.WriteLine(toDisplay);
        }
        public static void ArrayMaker(string input, short[] array)
        {
            string[] subString = input.Split(' ');
            for (short i = 0; i <= subString.GetLength(0) - 1; i++)
            {
                array[i] = short.Parse(subString[i]);
            }
        } //raboti
        public static void ArrayAscendingSorter(short[] array)
        {
            short leftLimit = 0;
            short rightLimit = (short)(array.GetLength(0) - 1);
            short indexMax = 0;
            short indexMin = 0;
            short tempMin;
            short tempMax;
            short min;
            short max;
            
            while (leftLimit <= rightLimit)
            {
                min = array[leftLimit];
                max = array[leftLimit];
                bool minFound = false;
                bool maxFound = false;
                for (short j = leftLimit; j <= rightLimit; j++)
                {
                    if (array[j] <= min)
                    {
                        min = array[j];
                        indexMin = j;
                        minFound = true;
                    }
                    if (array[j] >= max)
                    {
                        max = array[j];
                        indexMax = j;
                        maxFound = true;
                    }
                }

                if (indexMin != leftLimit && minFound == true)
                {
                    tempMin = array[leftLimit];
                    array[leftLimit] = min;
                    array[indexMin] = tempMin;
                }
                bool anotherBool = false;
                if (maxFound == false && max == array[leftLimit]) anotherBool = true;
                if ((indexMax != rightLimit && maxFound == true) || anotherBool == true)
                {
                    if (leftLimit == indexMax)
                    {
                        indexMax = indexMin;
                    }
                    tempMax = array[rightLimit];
                    array[rightLimit] = max;
                    array[indexMax] = tempMax;
                }
                leftLimit += 1;
                rightLimit -= 1;
            }
        }
        public static string ArraySeparator(short[] separateMe)
        {
            StringBuilder done = new StringBuilder();

            for (short i = 0; i <= separateMe.GetLength(0) - 1; i++)
            {
                done.Append(separateMe[i]);
                if (i != separateMe.GetLength(0) - 1) done.Append(' ');
            }

            return (string)done.ToString();
        }  //raboti
 
    }
}