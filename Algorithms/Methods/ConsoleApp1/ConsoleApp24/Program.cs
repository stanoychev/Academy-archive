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
            string input = Console.ReadLine();
            int[] container = new int[5];
            FillContainer(input, container);
            PrintContainer(container);
        }
        public static void FillContainer(string input, int[] emptyContainer)
        {
            string[] subString = input.Split(' ');
            for (int i = 0; i <= subString.GetLength(0) - 1; i++)
            {
                emptyContainer[i] = short.Parse(subString[i]);
            }
        }
        public static void PrintContainer(int[] container)
        {
            Console.WriteLine(GetMin(container));
            Console.WriteLine(GetMax(container));
            Console.WriteLine("{0:f2}", GetAverage(container));
            Console.WriteLine(GetSum(container));
            Console.WriteLine(GetProduct(container));
        }
        public static int GetMin(int[] container)
        {
            int min = container[0];
            for (int i = 1; i <= container.GetLength(0) - 1; i++)
            {
                if (container[i] < min)
                {
                    min = container[i];
                }
            }
            return min;
        }
        public static int GetMax(int[] container)
        {
            int max = container[0];
            for (int i = 1; i <= container.GetLength(0) - 1; i++)
            {
                if (container[i] > max)
                {
                    max = container[i];
                }
            }
            return max;
        }
        public static double GetAverage(int[] container)
        {
            double avg = ((double)GetSum(container)) / 5.0;

            return avg;
        }
        public static int GetSum(int[] container)
        {
            int sum = 0;
            for (int i = 0; i <= container.GetLength(0) - 1; i++)
            {
                sum += container[i];
            }
            return sum;
        }
        public static long GetProduct(int[] container)
        {
            long prod = 1;
            for (int i = 0; i <= container.GetLength(0) - 1; i++)
            {
                prod = prod * container[i];
            }
            return prod;
        }
    }
}