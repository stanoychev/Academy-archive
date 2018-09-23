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
            } //procheteno

            int max = 0;
            int currentMax = 0;
            for (int i = 0; i <= n - 2; i++)
            {
                if (array[i] < array[i + 1])
                {
                    currentMax++;
                    int j;
                    for (j = i; j <= n - 2 && array[j] < array[j + 1]; j++)
                    {
                        currentMax++;
                    }
                    i = j;
                }

                if (currentMax > max)
                {
                    max = currentMax;
                }
                currentMax = 0;
            }
            Console.WriteLine(max);
        }
    }
}