using System;
using System.Collections.Generic;
using System.Linq;

namespace SortingMethodsLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNum = new Random();
            //Console.SetWindowSize(120, 51);
            //Console.SetBufferSize(120, 51);

            int[] array = TotallyRandomInt32Array(300, randomNum); //-150 to 150

            ShuffleArray(array, randomNum);
            Console.WriteLine("Shuffling:");
            DisplayArray(array);

            array = QuickSort(array);
            Console.WriteLine("Quick Sort");
            DisplayArray(array);

            int findNumber = randomNum.Next(-150,150);
            Console.WriteLine("Linear search");
            Console.WriteLine(LinearSearch(array, findNumber));
            Console.WriteLine("Bynary search (itterative)");
            Console.WriteLine(BinarySearchItterative(array, findNumber));
            Console.WriteLine("Bynary search (recursive)");
            Console.WriteLine(BinarySearchRecursive(array, findNumber));
            //Console.WriteLine("Interpolation search");
            //Console.WriteLine(InterpolationSearchNotWorkingYet(array, findNumber));
        }
        
        public static int[] TotallyRandomInt32Array(int length, Random randomNum)
        {
            int[] array = new int[length];
            for (int i = 0; i <= length - 1; i++)
            {
                array[i] = randomNum.Next(-150, 150);
            }
            return array;
        }

        public static void DisplayArray(int[] array)
        {
            foreach (int item in array)
            {
                Console.Write("{0} ", item);
            }
            Console.WriteLine();
            Console.WriteLine();
        }

        public static void ShuffleArray(int[] array, Random randomNum)
        {
            for (int i = 0; i <= array.Length - 1; i++)
            {
                int position = randomNum.Next(i, array.Length - 1);
                int temp = array[i];
                array[i] = array[position];
                array[position] = temp;
            }
        }

        public static int[] QuickSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }

            int pivotIndex = PivotIndexPicker(array.ToArray());
            int pivot = array[pivotIndex];

            List<int> left = new List<int>();
            List<int> right = new List<int>();

            for (int i = 0; i <= array.Length - 1; i++)
            {
                if (i != pivotIndex)
                {
                    if (array[i] < pivot)
                    {
                        left.Add(array[i]);
                    }
                    else
                    {
                        right.Add(array[i]);
                    }
                }
            }

            List<int> result = new List<int>();
            List<int> sortedLeft = QuickSort(left.ToArray()).ToList();
            List<int> sortedRight = QuickSort(right.ToArray()).ToList();

            result.AddRange(sortedLeft);
            result.Add(pivot);
            result.AddRange(sortedRight);

            return result.ToArray();
        }

        public static int PivotIndexPicker(int[] array)
        {
            if (array.Length == 0)
            {
                throw new ArgumentException("What is that empty list????");
            }
            else if (array.Length <= 2)
            {
                return 0;
            }
            else //list.Count >= 3
            {
                int a = array[0];
                int b = array[(array.Length - 1) / 2];
                int c = array[array.Length - 1];

                if (a == b && b == c)
                {
                    return 0;
                }
                else if (a == b || b == c || a == c)
                {
                    if (a == b)
                    {
                        return 0;
                    }
                    else if (b == c)
                    {
                        return (array.Length - 1) / 2;
                    }
                    else // if (a == c)
                    {
                        return array.Length - 1;
                    }
                }
                else //a, b and c are now three different nums
                {
                    if (a > b)
                    {
                        if (b > c)
                        {
                            return (array.Length - 1) / 2;
                        }
                        else
                        {
                            if (c > a)
                            {
                                return 0;
                            }
                            else
                            {
                                return array.Length - 1;
                            }
                        }
                    }
                    else
                    {
                        if (b < c)
                        {
                            return (array.Length - 1) / 2;
                        }
                        else
                        {
                            if (c < a)
                            {
                                return 0;
                            }
                            else
                            {
                                return array.Length - 1;
                            }
                        }
                    }
                }
            }
        }

        public static string LinearSearch(int[] array, int findNumber)
        {
            for (int i = 0; i <=array.Length-1; i++)
            {
                if (array[i]==findNumber)
                {
                    return string.Format("Number {0} found at position {1} by {2} steps.", findNumber, i, i);
                }
            }
            return string.Format("Number {0} not found.", findNumber);
        }

        public static string BinarySearchItterative(int[] array, int findNumber)
        {
            int min = 0;
            int mid;
            int max = array.Length - 1;
            int steps = 0;
            
            while (true)
            {
                if (min < max)
                {
                    mid = (min + max) / 2;
                    steps++;
                    if (findNumber < array[mid])
                    {
                        max = mid;
                    }
                    else if (findNumber > array[mid])
                    {
                        min = mid + (min + max) % 2;
                    }
                    else
                    {
                        return string.Format("Number {0} found at position {1} by {2} steps.", findNumber, mid, steps);
                    }
                }
                else
                {
                    return string.Format("Number {0} not found.", findNumber);
                }
            }
        }
        
        public static string BinarySearchRecursive(int[] array, int findNumber, int min = 0, int steps = 0, int max = -1)
        {
            if (max == -1)
            {
                max = array.Length - 1;
            }
            
            if (min < max)
            {
                int mid = (min + max) / 2;
                steps++;
                if (findNumber < array[mid])
                {
                    max = mid;
                }
                else if (findNumber > array[mid])
                {
                    min = mid + (min + max) % 2;
                }
                else
                {
                    return string.Format("Number {0} found at position {1} by {2} steps.", findNumber, mid, steps);
                }
            }
            else
            {
                return string.Format("Number {0} not found.", findNumber);
            }

            return BinarySearchRecursive(array, findNumber, min, steps, max);
        }

        public static string InterpolationSearchNotWorkingYet(int[] array, int toFind)
        {
            int min = 0;
            int mid = 0;
            int max = array.Length - 1;
            int steps = 0;

            while (array[min] <= toFind && toFind <= array[max])
            {
                if (array[mid]==toFind)
                {
                    return string.Format("Number {0} found at position {1} by {2} steps.", toFind, mid, steps);
                }
                mid = ((toFind - array[min]) * (max - min)) / (array[max] - array[min]);
                if (array[mid] < toFind)
                {
                    min = mid + 1;
                }
                else if (array[mid] > toFind)
                {
                    max = mid - 1;
                }
            }
            if (array[min] == toFind)
            {
                return string.Format("Number {0} found at position {1} by {2} steps.", toFind, min, steps);
            }
            else if (array[max] == toFind)
            {
                return string.Format("Number {0} found at position {1} by {2} steps.", toFind, max, steps);
            }
            else
            {
                return string.Format("Number {0} not found.", toFind);
            }
        }
    }
}
