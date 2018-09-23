using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class MazeRunner
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            byte[] array = new byte[n]; // 1: left; 2: right; 3: straight
            for (int i = 0; i <= n - 1; i++)
            {
                short num = short.Parse(Console.ReadLine());
                byte p4 = (byte)(num % 10);
                byte p3 = (byte)((num / 10) % 10);
                byte p2 = (byte)((num / 100) % 10);
                byte p1 = (byte)((num / 1000) % 10);
                byte evenSum = 0;
                byte oddSum = 0;
                if (p1 % 2 == 0) evenSum += p1; else oddSum += p1;
                if (p2 % 2 == 0) evenSum += p2; else oddSum += p2;
                if (p3 % 2 == 0) evenSum += p3; else oddSum += p3;
                if (p4 % 2 == 0) evenSum += p4; else oddSum += p4;
                if (evenSum > oddSum) array[i] = 1; else if (evenSum < oddSum) array[i] = 2; else array[i] = 3;
            }
            for (int i = 0; i <= n - 1; i++)
            {
                switch (array[i])
                {
                    case 1: Console.WriteLine("left"); break;
                    case 2: Console.WriteLine("right"); break;
                    case 3: Console.WriteLine("straight"); break;
                }
            }
        }
    }
}