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
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            StringToSDArray(Console.ReadLine(), array);

            Console.WriteLine(IndexOfFirstElement(array));
        }
        public static void StringToSDArray(string input, int[] emptyArray)
        {
            string[] numbers = input.Split(' ');
            for (int i = 0; i <= numbers.GetLength(0) - 1; i++)
            {
                emptyArray[i] = int.Parse(numbers[i]);
            }
        }
        public static int IndexOfFirstElement(int[] array)
        {
            int index = -1;
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                if ((i > 0 && i < array.GetLength(0) - 1) && (array[i] > array[i - 1] && array[i] > array[i + 1]))
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

    }
}