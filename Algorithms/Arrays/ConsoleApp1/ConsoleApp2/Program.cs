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
            int[] arr1 = new int[n];
            int[] arr2 = new int[n];

            ArrFill(arr1);
            ArrFill(arr2);

            SameArrChecker(arr1, arr2);
        }
        public static void ArrFill(int[] arr)
        {
            for (int i = 0; i <=arr.GetLength(0)-1; i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
        }
        public static void SameArrChecker (int[] arr1, int[] arr2)
        {
            bool equal = true;
            for (int i = 0; i <=arr1.GetLength(0)-1; i++)
            {
                if (arr1[i] != arr2[i])
                {
                    equal = false;
                }
            }
            if (equal)
            {
                Console.WriteLine("Equal");
            }
            else
            {
                Console.WriteLine("Not equal");
            }
        }
    }
}