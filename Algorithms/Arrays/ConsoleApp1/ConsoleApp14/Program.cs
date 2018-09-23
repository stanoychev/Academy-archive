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
            int[] array = new int[n];

            for (int i = 0; i <= n - 1; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            int x = int.Parse(Console.ReadLine());

            Console.WriteLine(Recursive(array,x, 0, array.Length-1));
        }

        public static int Recursive(int[] arr, int num, int min, int max)
        {
            if (min < max)
            {
                int middle = (min + max) / 2;

                if (num < arr[middle])
                {
                    max = middle;
                }
                else if (num > arr[middle])
                {
                    min = middle + (min + max) % 2;
                }
                else
                {
                    return middle;
                }
            }
            else
            {
                return -1;
            }
            return Recursive(arr, num, min, max);
        }
    }
}