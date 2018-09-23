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
            int k = int.Parse(Console.ReadLine());
            int[] array = new int[n];

            for (int i = 0; i <= n - 1; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            } //procheteno

            Array.Sort(array);

            int sum = 0;

            for (int i = 0; i <= k-1; i++)
            {
                sum += array[array.GetLength(0)-1-i];
            }

            Console.WriteLine(sum);
        }
    }
}