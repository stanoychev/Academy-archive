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
            char[] array1 = ReadArray();
            char[] array2 = ReadArray();

            StringChecker(array1, array2);
        }
        public static char[] ReadArray()
        {
            string array = Console.ReadLine();
            char[] simbols = new char[array.Length];
            for (int i = 0; i <= array.Length - 1; i++)
            {
                simbols[i] = array[i];
            }
            return simbols;
        }
        public static void StringChecker(char[] array1, char[] array2)
        {
            if (array1.GetLength(0) == array2.GetLength(0))
            {
                char final = '=';
                for (int i = 0; i <= array1.GetLength(0) - 1; i++)
                {
                    if (array1[i] > array2[i])
                    {
                        final = '>';
                        break;
                    }
                    else if (array1[i] < array2[i])
                    {
                        final = '<';
                        break;
                    }
                }
                Console.WriteLine(final);
            }
            else if (array1.GetLength(0) > array2.GetLength(0))
            {
                char final = '>';
                for (int i = 0; i <= array2.GetLength(0) - 1; i++)
                {
                    if (array1[i] > array2[i])
                    {
                        final = '>';
                        break;
                    }
                    else if (array1[i] < array2[i])
                    {
                        final = '<';
                        break;
                    }
                }
                Console.WriteLine(final);
            }
            else if (array1.GetLength(0) < array2.GetLength(0)) //az / zaa
                
            {
                char final = '<';
                for (int i = 0; i <= array1.GetLength(0) - 1; i++)
                {
                    if (array1[i] > array2[i])
                    {
                        final = '>';
                        break;
                    }
                    else if (array1[i] < array2[i])
                    {
                        final = '<';
                        break;
                    }
                }
                Console.WriteLine(final);
            }
        }
    }
}