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
            for (int i = 0; i <= subString.GetLength(0) - 1; i++)
            {
                array[i] = int.Parse(subString[i]);
            }
        } //raboti
        public static void ArrayAscendingSorter(int[] array)
        {
            int[] tempArray = new int[array.GetLength(0)];
            bool[] boolArray = new bool[array.GetLength(0)]; //default false
            int a = 0;
            int b = array.GetLength(0) - 1;

            while (a <= b)
            {
                tempArray[a] = GetMin(array, boolArray);
                if(a!=b) tempArray[b] = GetMax(array, boolArray);
                a = a + 1;
                b = b - 1;
            }
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                array[i] = tempArray[i];
            }
        } //raboti
        public static int GetMax(int[] array, bool[] boolArray)
        {
            for (int j = 0; j < array.GetLength(0) - 1; j++) //tva vyrti dokato ... ne moga da go obqsnq
            {
                if (boolArray[j] == false)
                {
                    int max = array[j];
                    int indexOfMaxNum = 0;
                    for (int i = 1; i <= array.GetLength(0) - 1; i++)
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
        public static int GetMin(int[] array, bool[] boolArray)
        {
            for (int j = 0; j < array.GetLength(0) - 1; j++) //tva vyrti dokato ... ne moga da go obqsnq
            {
                if (boolArray[j] == false)
                {
                    int min = array[j];
                    int indexOfMinNum = 0;
                    for (int i = 1; i <= array.GetLength(0) - 1; i++)
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
        public static void DA(int[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        } //Display Array
        public static void DA(short[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        public static void DA(bool[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                if (array[i] == true) Console.Write("1 ");
                else Console.Write("0 ");
            }
            Console.WriteLine();
        }
        public static void DA(char[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        public static void DA(string[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
    }
}