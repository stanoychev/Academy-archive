using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class PaperCutter
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            string tmp = Convert.ToString(n, 2);
            bool[] array = new bool[11];

            for (int i = 0; i <= tmp.Length - 1; i++)
                if (tmp[tmp.Length - 1 - i] == '1') array[10 - i] = true;

            for (int i = 0; i <= 10; i++)
                if (array[i] == false) Console.WriteLine("A{0}", i);
        }
    }
}