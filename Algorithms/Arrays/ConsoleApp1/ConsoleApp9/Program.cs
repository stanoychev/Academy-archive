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
            short n = short.Parse(Console.ReadLine());

            short[] array = new short[n];
            bool[] boolArray = new bool[n]; //all false

            for (short i = 0; i <= n - 1; i++)
            {
                array[i] = short.Parse(Console.ReadLine());
            } //procheteno

            short current=0;
            short currentCounter = 0;
            short maxRepeat = 0;
            short num=0;
            for (short i = 0; i <= n - 1; i++)
            {
                if(boolArray[i]==false)
                {
                    current = array[i];
                    for (int j = i; j <= n-1; j++)
                    {
                        if (array[j]==current)
                        {
                            currentCounter++;
                            boolArray[j] = true;
                        }
                    }
                }
                if (currentCounter>=maxRepeat)
                {
                    maxRepeat = currentCounter;
                    num = current;
                }
                currentCounter = 0;
            }
            Console.WriteLine("{0} ({1} times)",num,maxRepeat);
        }
    }
}