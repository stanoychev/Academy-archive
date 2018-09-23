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
            //int n = int.Parse(Console.ReadLine());
            //int[] pesho = new int[n];

            //Random randNum = new Random();
            //for (int i = 0; i <= pesho.Length - 1; i++)
            //{
            //    pesho[i] = randNum.Next(-9, 9);
            //}

            //for (int i = 0; i <= pesho.Length - 1; i++)
            //{
            //    Console.WriteLine(pesho[i]);
            //}

            //end of random number generator

            bool doLoop = true;
            List<int> sorted = new List<int>();
            List<int> arr = new List<int>();

            int n = int.Parse(Console.ReadLine());

            int initialSize = n;
            for (int i = 0; i <= n - 1; i++)
            {
                //arr.Add(pesho[i]);
                arr.Add(int.Parse(Console.ReadLine()));
            }

            for (int i = 0; i < (n / 2 + n % 2); i++)
            {
                if (arr[i] > arr[n - 1 - i])
                {
                    arr.RemoveAt(n - 1 - i);
                    arr.RemoveAt(i);
                    n = n - 2;
                    i = i - 1;
                }
            }

            while (doLoop)
            {
                foreach (int element in arr)
                {
                    sorted.Add(element);
                }
                sorted.Sort();
                doLoop = false;
                for (int i = 0; i <= arr.Count - 1; i++) // && !doLoop; i++)
                {
                    if (arr[i] != sorted[i])
                    {
                        for (int j = sorted.Count - 1; j>=0 ; j--)
                        {
                            if (sorted[j] == arr[i])
                            {
                                if (i + 1 <= arr.Count - 1 && arr[i] > arr[i + 1])
                                {
                                    arr.RemoveAt(i);
                                    break;
                                }
                                else if (arr[j] < arr[j - 1])
                                {
                                    arr.RemoveAt(j);
                                    break;
                                }
                            }
                        }
                        doLoop = true;
                        sorted.Clear();
                        break;
                    }
                    //if (i == arr.Count - 1) break;
                }
            }
            Console.WriteLine(initialSize - arr.Count);
        }
    }
}
