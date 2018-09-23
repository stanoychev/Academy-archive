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
            int mid;
            int min = 0;
            int n = int.Parse(Console.ReadLine());
            int max = n - 1;
            int[] array = new int[n];

            for (int i = 0; i <= n - 1; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            int x = int.Parse(Console.ReadLine());

            while (true)
            {
                if (min < max)
                {
                    mid = (min + max) / 2;

                    if (x < array[mid])
                    {
                        max = mid;
                    }
                    else if (x > array[mid])
                    {
                        min = mid + (min + max) % 2;
                    }
                    else
                    {
                        Console.WriteLine(mid);
                        return;
                    }
                }
                else
                {
                    Console.WriteLine(-1);
                    return;
                }
            }
        }
    }
}