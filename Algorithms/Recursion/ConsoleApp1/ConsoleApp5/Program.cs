using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<int> list = new List<int>();
            for (int i = 0; i <=n-1; i++)
            {
                list.Add(int.Parse(Console.ReadLine()));
            }
            int x = int.Parse(Console.ReadLine());
            FindX(list, x); //, 0,pesho.Count-1);
        }
        public static void FindX(List<int> list, int x) //, int min, int max)
        {
            if (x < list[(0 + list.Count-1) / 2])
            {
                list.RemoveRange((0 + list.Count) / 2, list.Count / 2);
                //max = (0 + list.Count-1) / 2;
                FindX(list, x);
            }

            else if (x > list[(0 + list.Count-1) / 2])
            {
                list.RemoveRange(0, list.Count / 2);
                //min = (0 + list.Count) / 2;
                FindX(list, x);
            }
            else if (x == list[(0 + list.Count-1) / 2])
            {
                Console.WriteLine ((0 + list.Count-1) / 2);
            }
            else // if (min >= max)
            {
                Console.WriteLine(- 1);
            }
        }
    }
}
