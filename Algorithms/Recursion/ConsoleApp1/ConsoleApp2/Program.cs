using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Console.WriteLine(Fact(n));
        }
        public static int Fact(int n)
        {
            if (n==1)
            {
                return 1;
            }

            return n * Fact(n - 1);
        }
    }
}
