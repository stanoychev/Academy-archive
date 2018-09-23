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
            byte n = byte.Parse(Console.ReadLine());

            if (n>=1 && n <= 20)
            {
                Console.WriteLine(SmallFact(n));
            } else if (n>=21 && n<=99)
            {
                List<byte> resultNum = new List<byte>();
                Factorial(n, resultNum);
                PrintList(resultNum);
            }
            else
            {
                n = 99;
                List<byte> resultNum = new List<byte>();
                Factorial(n, resultNum);
                Console.Write("00");
                PrintList(resultNum);
            }

        }
        public static void Factorial (byte n, List<byte> resultNum)
        {
                long smallFact = SmallFact(20);
                List<byte> num = new List<byte>();
                List<byte> additionalNum = new List<byte>();

                for (byte i = 0; i <= smallFact.ToString().Length-1; i++)
                {
                    num.Add((byte)smallFact.ToString()[smallFact.ToString().Length - 1-i]);
                }

                for (byte i = 21; i <=n; i++)
                {
                    byte num1 = 0; // del?
                    byte num2 = 0; // del?

                    if (i % 10 == 0)
                    {
                        num.Add(0);
                        MultiplyMegaLongNum(num, i);
                    } // tva e za 20! 30! 40! ...
                    else
                    {
                        num1 = (byte)(i % 10); // 21 -> 1
                        num2 = (byte)(i / 10); // 21 -> 2

                        additionalNum = num;

                        MultiplyMegaLongNum(num, num1);

                        MultiplyMegaLongNum(additionalNum, num2);

                        SumGigaLongNumsWithSecondNumOffsat(num, additionalNum, resultNum);

                    } //tva e za vsi4ki drugi 4isla
                }
        } //raboti
        public static long SmallFact(byte n)
        {
            long smallFact = 1;
            for (byte i = 1; i <= n; i++)
            {
                smallFact = smallFact * i;
            }
            return smallFact;
        } //raboti
        public static void MultiplyMegaLongNum(List<byte> num, byte n)
        {
            byte ostatyk = 0;
            for (byte j = 0; j <= num.Count - 1; j++)
            {
                num[j] = (byte)((ostatyk + num[j] * (n / 10)) % 10);
                ostatyk = (byte)((ostatyk + num[j] * (n / 10)) / 10);

                if (j == num.Count - 1 && ostatyk != 0)
                {
                    num.Add(ostatyk);
                }
            }
        }
        public static void SumGigaLongNumsWithSecondNumOffsat(List<byte> firstNum, List<byte> secondNum, List<byte> resultNum)
        {
            byte smallerNum;
            byte biggerNum;
            byte ostatyk = 0;

            if (firstNum.Count > secondNum.Count)
            {
                biggerNum = (byte)(firstNum.Count);
                smallerNum = (byte)(secondNum.Count);
            }
            else
            {
                biggerNum = (byte)(secondNum.Count);
                smallerNum = (byte)(firstNum.Count);
            }
            Console.WriteLine("before");
            Console.WriteLine("first {0}", firstNum.Count);
            Console.WriteLine("second {0}", secondNum.Count);
            resultNum.Add(firstNum[0]);

            // slagat se nuli eventualno taka 4e da... da
            
            if (secondNum.Count > firstNum.Count-1)
                for (byte i = 1; i <=Math.Abs((biggerNum+1) - smallerNum); i++) // 20 - 19 = 1
                {
                    firstNum.Add(0);
                } //tova dobavq eventualno nuli na pyrvoto chislo

            Console.WriteLine("after");
            Console.WriteLine("first {0}", firstNum.Count);
            Console.WriteLine("second {0}", secondNum.Count);

            for (byte i = 0; i <= secondNum.Count - 1; i++)
            {
                resultNum.Add((byte)((firstNum[i + 1] + secondNum[i] + ostatyk) % 10));
                ostatyk = (byte)((firstNum[i + 1] + secondNum[i] + ostatyk) / 10);
            }

            if (ostatyk!=0)
            {
                resultNum.Add(ostatyk);
            }


        }
        public static void PrintList(List<byte> printMe)
        {
            for (byte i = 0; i <= printMe.ToString().Length - 1; i++)
            {
                Console.Write(printMe[i]);
            }
        }
    }   
}