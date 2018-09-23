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
            List<int> array = new List<int>();

            for (int i = 0; i <= n - 1; i++)
            {
                array.Add(int.Parse(Console.ReadLine()));
            } //procheteno

            //Array.Sort(array); sheguvam se

            while (array.Count()>=1)
            {
                int i;
                int currentMin = array[0];
                int positionMin = 0;
                for (i = 1; i <= array.Count() - 1; i++)
                {
                    if(array[i]<= currentMin)
                    {
                        currentMin = array[i];
                        positionMin = i;
                    }
                }
                Console.WriteLine(currentMin);
                array.RemoveAt(positionMin);
            }
        }
    }
}