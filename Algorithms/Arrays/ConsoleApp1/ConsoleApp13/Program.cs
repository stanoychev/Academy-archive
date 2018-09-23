using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Text;
using Wintellect.PowerCollections;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            OrderedDictionary<int,int> dict = new OrderedDictionary<int, int>();
            for (int i = 0; i <= n - 1; i++)
            {
                dict.Add(int.Parse(Console.ReadLine()), i);
            }
            int x = int.Parse(Console.ReadLine());

            if (dict.ContainsKey(x))
            {
                Console.WriteLine(dict[x]);
            }
            else
            {
                Console.WriteLine(-1);
            }
        }
    }
}