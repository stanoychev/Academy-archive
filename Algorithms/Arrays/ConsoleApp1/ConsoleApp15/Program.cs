using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp15
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            n++;
            bool[] primeArray = new bool[n]; //all false
            int initialPrimeNum = 2;

            for (int i = initialPrimeNum; i <= Math.Sqrt(n); i++)
            {
                if (primeArray[i] == false)
                {
                    for (int j = 0; i * i + i * j <= n - 1; j++)
                    {
                        if (i * i + i * j <= n)
                        {
                            primeArray[i * i + i * j] = true;
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }

            for (int i = n-1; i >= 2; i--)
            {
                if (!primeArray[i])
                {
                    Console.WriteLine(i);
                    break;
                }
            }

            //DIsplay(primeArray);
        }

        public static void DIsplay(bool[] arr)
        {
            int stuppToDisplay = 6;
            int cursorpositionY = 0;

            for (int i = 0; ; i++)
            {
                int cursorpositionX = 0;
                for (int j = 0; j < stuppToDisplay; j++)
                {
                    if (i * stuppToDisplay + j > arr.Length - 1)
                    {
                        Console.WriteLine();
                        return;
                    }
                    if (i * stuppToDisplay + j < 2)
                    {
                        j = 2;
                    }
                    string isPrime;
                    if (arr[i * stuppToDisplay + j])
                    {
                        isPrime = "NOT prime";
                    }
                    else
                    {
                        isPrime = "prime";
                    }
                    Console.SetCursorPosition(cursorpositionX, cursorpositionY);
                    Console.Write("{0} is {1}", i * stuppToDisplay + j, isPrime);
                    cursorpositionX += 20;
                }
                cursorpositionY++;
            }
        }
    }
}
