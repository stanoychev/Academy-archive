using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using System.Diagnostics;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                try
                {
                    short n = short.Parse(Console.ReadLine());
               
            //short n = short.Parse(Console.ReadLine());
            short[] array = new short[n]; //create empty global array

            ArrayGenerator(array);
            //Console.WriteLine("Initial");
            //DA(array);

            Stopwatch tiktak = new Stopwatch();
            tiktak.Start();
            Array.Sort(array);
            tiktak.Stop();
            TimeSpan duration = tiktak.Elapsed;
            Console.WriteLine("{0} Integrated sort method", duration);
            //short n = short.Parse(Console.ReadLine());
            //short[] array = new short[n]; //create empty global array
            //string toArrayAndSort = Console.ReadLine();

            //List<short> arrayList = new List<short>();
            //do
            //{
            //try
            //{
            //arrayList.Add(short.Parse(Console.ReadLine()));
            //}
            //catch (Exception)
            //{
            //break;
            //}
            //} while (true);
            //short[] array = arrayList.ToArray();
            //string toArrayAndSort = new string(array);

            //ArrayMaker(toArrayAndSort, array); //string to array

            ArrayGenerator(array);

            tiktak.Reset();
            tiktak.Start();
            ArrayAscendingSorter(array); //sorting the array
            tiktak.Stop();
            duration = tiktak.Elapsed;
            Console.WriteLine("{0} Doubblebubble sort method", duration);

            ArrayGenerator(array);

            tiktak.Reset();
            tiktak.Start();
            ArrayAscendingBubbleSorter(array); //sorting the array
            tiktak.Stop();
            duration = tiktak.Elapsed;
            Console.WriteLine("{0} Singlebubble sort method", duration);

            ArrayGenerator(array);

            tiktak.Reset();
            tiktak.Start();
            ArrayAscendingBGCoderSorter(array); //sorting the array
            tiktak.Stop();
            duration = tiktak.Elapsed;
            Console.WriteLine("{0} BGCoder sort method", duration);
            Console.WriteLine("HACKER");
            string toDisplay = ArraySeparator(array); //displaying the array

                    // Console.WriteLine(toDisplay);
                    break;
                }
                catch (Exception)
                {
                    Console.WriteLine("Ni sa prai vyvedi celo 4islo");
                }
            }
        }
        public static void ArrayMaker(string input, short[] array)
        {
            string[] subString = input.Split(' ');
            for (short i = 0; i <= subString.GetLength(0) - 1; i++)
            {
                array[i] = short.Parse(subString[i]);
            }
        } //raboti
        public static void ArrayAscendingSorter(short[] array)
        {
            short leftLimit = 0;
            short rightLimit = (short)(array.GetLength(0) - 1);
            short indexMax = 0;
            short indexMin = 0;
            short tempMin;
            short tempMax;
            short min;
            short max;
          //  int i = 0; //del me
            while (leftLimit <= rightLimit)
            {
              //  Console.WriteLine("Itteration {0}", leftLimit); i++;
                min = array[leftLimit];
                max = array[leftLimit];
                bool minFound = false;
                bool maxFound = false;
                for (short j = (short)(leftLimit); j<=rightLimit; j++)
                {
                    if (array[j] <= min)
                    {
                        min = array[j];
                        indexMin = j;
                        minFound = true;//ne e dobra ideq
                    }
                    if (array[j] >= max)
                    {
                        max = array[j];
                        indexMax = j;
                        maxFound = true;
                    }
                }

                //Console.WriteLine("Min detected = {0} between {1} and {2}, position {3}" , min, leftLimit, rightLimit, indexMin);
                //Console.WriteLine("Max detected = {0} between {1} and {2}, position {3}", max, leftLimit, rightLimit, indexMax);

                if (indexMin!=leftLimit && minFound==true) 
                {
                    tempMin = array[leftLimit];
                    array[leftLimit] = min;
                    array[indexMin] = tempMin;
                }
                bool anotherBool = false;
                if (maxFound == false && max == array[leftLimit]) anotherBool = true;
                if ((indexMax != rightLimit && maxFound == true) || anotherBool==true)
                {
                    if (leftLimit==indexMax)
                    {
                        indexMax = indexMin;
                    }
                    tempMax = array[rightLimit];
                    array[rightLimit] = max;
                    array[indexMax] = tempMax;
                }
                
             //   DA(array);
            leftLimit+=1;
            rightLimit-=1;
            }
        }
        public static string ArraySeparator(short[] separateMe)
        {
            StringBuilder done = new StringBuilder();

            for (short i = 0; i <= separateMe.GetLength(0) - 1; i++)
            {
                done.Append(separateMe[i]);
                if (i != separateMe.GetLength(0) - 1) done.Append(' ');
            }

            return (string)done.ToString();
        }  //raboti
        public static void DA(int[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        } //Display Array
        public static void DA(short[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        public static void DA(bool[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                if (array[i] == true) Console.Write("1 ");
                else Console.Write("0 ");
            }
            Console.WriteLine();
        }
        public static void DA(char[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        public static void DA(string[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0} ", array[i]);
            }
            Console.WriteLine();
        }
        public static void ArrayGenerator(short[] array)
        {
            Random ludnica = new Random();
            for (short i = 0; i < (short)(array.GetLength(0)- 1); i++)
            {
                array[i] = (short)ludnica.Next(-9, 9);
            }
        }
        public static void ArrayAscendingBubbleSorter(short[] array)
        {
            short min = 0;
            short indexMin = 0;
            for (short start = 0; start <= array.GetLength(0) - 1; start++)
            {
                min = array[start];
                for (short i = start; i <= array.GetLength(0) - 1; i++)
                {
                    if (array[i] <= min)
                    {
                        min = array[i];
                        indexMin = i;
                    }
                    array[indexMin] = array[start];
                    array[start] = min;
                }
                
            }
        }
        public static void ArrayAscendingBGCoderSorter(short[] array)
        {
            short[] tempArray = new short[array.GetLength(0)];
            bool[] boolArray = new bool[array.GetLength(0)]; //default false
            short a = 0;
            short b = (short)(array.GetLength(0) - 1);

            while (a <= b)
            {
                tempArray[a] = (short)GetMin(array, boolArray);
                if (a != b) tempArray[b] = (short)GetMax(array, boolArray);
                a = (short)(a + 1);
                b = (short)(b - 1);
            }
            for (short i = 0; i <= array.GetLength(0) - 1; i++)
            {
                array[i] = tempArray[i];
            }
        } //raboti
        public static int GetMax(short[] array, bool[] boolArray)
        {
            for (short j = 0; j < array.GetLength(0) - 1; j++) //tva vyrti dokato ... ne moga da go obqsnq
            {
                if (boolArray[j] == false)
                {
                    short max = array[j];
                    short indexOfMaxNum = 0; Math.
                    for (short i = 1; i <= array.GetLength(0) - 1; i++)
                    {
                        if (array[i] >= max && boolArray[i] == false)
                        {
                            max = array[i];
                            indexOfMaxNum = i;
                        }
                    }
                    boolArray[indexOfMaxNum] = true;
                    return max;
                }
            }
            return 404;//ако стигне до тука нещо има грешка
        } //raboti
        public static int GetMin(short[] array, bool[] boolArray)
        {
            for (short j = 0; j < array.GetLength(0) - 1; j++) //tva vyrti dokato ... ne moga da go obqsnq
            {
                if (boolArray[j] == false)
                {
                    short min = array[j];
                    short indexOfMinNum = 0;
                    for (short i = 1; i <= array.GetLength(0) - 1; i++)
                    {
                        if (array[i] <= min && boolArray[i] == false)
                        {
                            min = array[i];
                            indexOfMinNum = i;
                        }
                    }
                    boolArray[indexOfMinNum] = true;
                    return min;
                }
            }
            return 505;//ако стигне до тука нещо има грешка
        } //raboti
        public static byte PowerExtractor(long num)
        {
            byte power = 0;
            while (num % 10 == 0)
            {
                num = num / 10;
                power++;
            }
            return power;
        }
        public static long IntegerExtractor(long num)
        {
            //long intNum = 0;
            while (num % 10 == 0)
            {
                num = num / 10;
            }
            return num;
        }
    }
}