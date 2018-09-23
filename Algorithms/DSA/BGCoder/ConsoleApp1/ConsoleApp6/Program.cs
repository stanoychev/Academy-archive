using System;
using System.Collections.Generic;
using System.Linq;

namespace ConsoleApp4
{
    class Program
    {
        static void Main(string[] args)
        {
            //int n = int.Parse(Console.ReadLine());

            long[] goldPrices = Console.ReadLine().Split().Select(x => long.Parse(x)).ToArray();
            int n = goldPrices.Length;

            long hypGold = 0;
            long hypMax = 0;
            long accumulated = 0;
            long today;
            long solidWin = 0;
            long solidWinDay = 0;
            long maxSolidWin = 0;
            long fromBegining = 0;
            long maximum = 0;

            long max = 0;
            for (int i = 0; i <= n - 1; i++)
            {
                today = goldPrices[i];
                accumulated = 0;

                int j = i;
                {
                    while (j > solidWinDay && accumulated <= today)
                    {
                        hypGold++;
                        accumulated += goldPrices[j - 1];
                        j--;
                    }
                    hypMax = hypGold * today - accumulated;
                    hypGold = 0;

                    if (hypMax > max)
                    {
                        max = hypMax;
                    }
                }


                if (i + 1 <= n - 1 && today > goldPrices[i + 1])
                {
                    solidWin += max;
                    max = 0;
                    solidWinDay = i + 1;
                }

                if (i == n - 1) //???????
                {
                    solidWin += max;
                }

                {
                    j = i;
                    accumulated = 0;
                    hypMax = 0;
                    while (j > 0 && accumulated <= today)
                    {
                        hypGold++;
                        accumulated += goldPrices[j - 1];
                        j--;
                    }
                    hypMax = hypGold * today - accumulated;
                    hypGold = 0;

                    if (hypMax > fromBegining)
                    {
                        fromBegining = hypMax;
                    }

                    //if (i==n-1)
                    //{
                    //    fromBegining += max;
                    //}
                }

                maximum = Math.Max(solidWin, fromBegining);
                hypMax = 0;
            }

            Console.WriteLine(maximum);
        }

    }
}