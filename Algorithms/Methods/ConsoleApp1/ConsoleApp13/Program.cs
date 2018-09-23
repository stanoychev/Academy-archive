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
            short[] tempArray = new short[array.GetLength(0)];
            bool[] boolArray = new bool[array.GetLength(0)]; //default false
            short a = 0;
            short b = (short)(array.GetLength(0) - 1);

            while (a <= b)
            {
                tempArray[a] = GetMin(array, boolArray);
                if (a != b) tempArray[b] = GetMax(array, boolArray);
                a = (short)(a + 1);
                b = (short)(b - 1);
            }
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                array[i] = tempArray[i];
            }
        } //raboti
        public static short GetMax(short[] array, bool[] boolArray)
        {
            for (short j = 0; j < array.GetLength(0) - 1; j++) //tva vyrti dokato ... ne moga da go obqsnq
            {
                if (boolArray[j] == false)
                {
                    short max = array[j];
                    short indexOfMaxNum = 0;
                    for (short i = 1; i <= array.GetLength(0) - 1; i++)
                    {
                        if (array[i] >= max && boolArray[i] == false)
                        {
                            max = array[i];
                            indexOfMaxNum = i;
                        }
                    }
                    boolArray[indexOfMaxNum] = true;
                    return max;
                }
            }
            return 404;//ако стигне до тука нещо има грешка
        } //raboti
        public static short GetMin(short[] array, bool[] boolArray)
        {
            for (short j = 0; j < array.GetLength(0) - 1; j++) //tva vyrti dokato ... ne moga da go obqsnq
            {
                if (boolArray[j] == false)
                {
                    short min = array[j];
                    short indexOfMinNum = 0;
                    for (short i = 1; i <= array.GetLength(0) - 1; i++)
                    {
                        if (array[i] <= min && boolArray[i] == false)
                        {
                            min = array[i];
                            indexOfMinNum = i;
                        }
                    }
                    boolArray[indexOfMinNum] = true;
                    return min;
                }
            }
            return 505;//ако стигне до тука нещо има грешка
        } //raboti
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