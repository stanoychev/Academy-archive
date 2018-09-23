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
            string[] numbers = Console.ReadLine().Split(' ');
            int x = int.Parse(Console.ReadLine());
            int[] array = new int[numbers.GetLength(0)];
            for (int i = 0; i <= n - 1; i++)
            {
                array[i] = int.Parse(numbers[i]);
            }
            CountX(array, x);
        }
        public static void CountX(int[] array, int x)
        {
            int counter = 0;
            foreach (int item in array)
            {
                if (x == item) counter++;
            }
            Console.WriteLine(counter);
        }
    }
}