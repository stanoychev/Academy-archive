using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace power
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int pow = int.Parse(Console.ReadLine());
            Console.WriteLine(Power(n, pow));
        }

        public static int Power(int n, int power)
        {
            if (power==1)
            {
                return n;
            }
            return n * Power(n, power - 1);
        }
    }
}
