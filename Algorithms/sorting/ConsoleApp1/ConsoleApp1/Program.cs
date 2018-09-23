using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace SortingMethodsLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            Random randomNum = new Random();
            //Console.SetWindowSize(120, 51);
            //Console.SetBufferSize(120, 51);

            int[] mainArray = TotallyRandomInt32Array(300, randomNum);

            ShuffleArray(mainArray, randomNum);
            Console.WriteLine("Shuffling:");
            DisplayArray(mainArray);

            int[] mainArrayToSelectionSort = mainArray;
            int[] mainArrayToBubbleSort = mainArray;
            int[] mainArrayToInsertionSort = mainArray;
            int[] mainArrayToQuickSort = mainArray;
            int[] mainArrayToMergeSort = mainArray;
            int[] mainArrayToCountingSort = mainArray;

            mainArrayToSelectionSort = SelectionSort(mainArrayToSelectionSort);
            SequentialChecker(mainArrayToSelectionSort);
            Console.WriteLine("Selection Sort");
            DisplayArray(mainArrayToSelectionSort);

            mainArrayToBubbleSort = BubbleSort(mainArrayToBubbleSort);
            SequentialChecker(mainArrayToBubbleSort);
            Console.WriteLine("Bubble Sort");
            DisplayArray(mainArrayToBubbleSort);

            mainArrayToInsertionSort = InsertionSort(mainArrayToInsertionSort);
            SequentialChecker(mainArrayToInsertionSort);
            Console.WriteLine("Insertion Sort");
            DisplayArray(mainArrayToInsertionSort);

            mainArrayToQuickSort = QuickSort(mainArrayToQuickSort);
            SequentialChecker(mainArrayToQuickSort);
            Console.WriteLine("Quick Sort");
            DisplayArray(mainArrayToQuickSort);

            mainArrayToMergeSort = MergeSort(mainArrayToMergeSort);
            SequentialChecker(mainArrayToMergeSort);
            Console.WriteLine("Merge Sort");
            DisplayArray(mainArrayToMergeSort);

            mainArrayToCountingSort = CountingSort(mainArrayToCountingSort);
            SequentialChecker(mainArrayToCountingSort);
            Console.WriteLine("Counting Sort");
            DisplayArray(mainArrayToCountingSort);

            //int[] array = ReadArrayFromBGCoder(); //BGCODER
            //array = MergeSort(array); //BGCODER
            //WriteArrayToBGCoder(array); //BGCODER
        }

        public static int[] InitializeArrNoRepNums(int arrayLength)
        {
            int[] array = new int[arrayLength];
            for (int i = 0; i <= arrayLength - 1; i++)
            {
                array[i] = i;
            }
            return array;
        }

        public static int[] InitializeArrRepNums(int arrayLength)
        {
            int[] array = new int[arrayLength];
            for (int i = 0; i <= (arrayLength - 1) / 2; i++)
            {
                array[i] = i;
                array[2 * i] = i;
            }
            return array;
        }

        public static int[] TotallyRandomInt32Array(int length, Random randomNum)
        {
            int[] array = new int[length];
            for (int i = 0; i <=length-1; i++)
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

        public static int[] ReadArrayFromBGCoder()
        {
            int n = int.Parse(Console.ReadLine());
            int[] array = new int[n];
            for (int i = 0; i <= n - 1; i++)
            {
                array[i] = int.Parse(Console.ReadLine());
            }
            return array;
        }

        public static void WriteArrayToBGCoder(int[] array)
        {
            for (int i = 0; i <= array.Length - 1; i++)
            {
                Console.WriteLine(array[i]);
            }
        }

        public static void SequentialChecker(int[] array)
        {
            for (int i = 0; i <= array.Length - 2; i++)
            {
                if (array[i] > array[i + 1])
                {
                    throw new ArgumentException("Not sequential numbers");
                }
            }
        }
        //SelectionSort done
        public static int[] SelectionSort(int[] array)
        {
            int minIndex = 0;
            if (array.Length > 0)
            {
                for (int i = 0; i <= array.Length - 2; i++)
                {
                    int min = array[i];
                    for (int j = i + 1; j <= array.Length - 1; j++)
                    {
                        if (array[j] <= min)
                        {
                            min = array[j];
                            minIndex = j;
                        }
                    }
                    if (array[i] != min)
                    {
                        int temp = array[i];
                        array[i] = min;
                        array[minIndex] = temp;
                    }
                }
            }
            return array;
        }
        //BubbleSort done
        public static int[] BubbleSort(int[] array)
        {
            for (int i = 0; i <= array.Length - 1; i++)
            {
                for (int j = 0; j <= array.Length - 2; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            return array;
        }
        //InsertionSort done
        public static int[] InsertionSort(int[] array)
        {
            for (int i = 0; i <= array.Length - 2; i++)
            {
                int j = i;
                while (array[j] > array[j + 1])
                {
                    int temp = array[j];
                    array[j] = array[j + 1];
                    array[j + 1] = temp;
                    if (j != 0)
                    {
                        j--;
                    }
                }
            }
            return array;
        }
        //QuickSort done
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
        //Mergesort done
        public static int[] MergeSort(int[] array)
        {
            if (array.Length <= 1)
            {
                return array;
            }
            else
            {
                int[] array1 = new int[array.Length / 2]; //2
                int[] array2 = new int[array.Length - array1.Length]; //3

                for (int i = 0; i <= array1.Length - 1; i++) //0 1
                {
                    array1[i] = array[i];
                }

                for (int i = array1.Length; i <= array.Length - 1; i++) //2 3 4
                {
                    array2[i - array1.Length] = array[i]; //0 1 2
                }

                int[] sortedArray1 = MergeSort(array1);
                int[] sortedArray2 = MergeSort(array2);

                return MergeArrays(sortedArray1, sortedArray2);
            }
        }

        public static int[] MergeArrays(int[] array1, int[] array2)
        {
            int[] result = new int[array1.Length+array2.Length];

            int k = 0; int i = 0; int j = 0;
            
            while (k<=result.Length-1)
            {
                if (i <= array1.Length - 1 && j <= array2.Length - 1)
                {
                    if (array1[i] <= array2[j])
                    {
                        result[k] = array1[i];
                        i++;
                        k++;
                    }
                    else
                    {
                        result[k] = array2[j];
                        j++;
                        k++;
                    }
                }
                else if (i <= array1.Length - 1 && j > array2.Length - 1)
                {
                    while (i <= array1.Length - 1)
                    {
                        result[k] = array1[i];
                        i++;
                        k++;
                    }
                }
                else if (i > array1.Length - 1 && j <= array2.Length - 1)
                {
                    while (j <= array2.Length - 1)
                    {
                        result[k] = array2[j];
                        j++;
                        k++;
                    }
                }
            }

            return result;
        }
        //Countingsort done
        public static int[] CountingSort(int[] array, int min = int.MinValue, int max =int.MaxValue)
        {
            if (min == int.MinValue && max == int.MaxValue) //min max not given => find them in the array, else use what`s given
            {
                min = array[0];
                max = array[0];
                for (int i= 1; i <= array.Length - 1; i++)
                {
                    if (array[i] <= min)
                    {
                        min = array[i];
                    }
                    if (array[i] >= max)
                    {
                        max = array[i];
                    }
                }
            }

            int[] countArray = new int[max-min+1]; //+1?
            int offset = 0 - min; //0 => 0; -5 => 5

            for (int i = 0; i <=array.Length-1; i++)
            {
                countArray[array[i]+offset]++;
            }
            int k = 0;
            List<int> outputArray = new List<int>();
            while (k<=countArray.Length-1)
            {
                if (countArray[k] != 0)
                {
                    for (int i = 0; i <=countArray[k]-1; i++)
                    {
                        outputArray.Add(k-offset);
                    }
                }
                k++;
            }
            return outputArray.ToArray();
        }
    }
}
