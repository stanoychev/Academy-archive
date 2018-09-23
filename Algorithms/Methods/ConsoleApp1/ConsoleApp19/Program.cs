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

            if (n<=1)
            {
                Console.WriteLine(1);
            }
            else if (n >= 2 && n <= 20)
            {
                Console.WriteLine(SmallFact(n));
            }
            else
            {
                long smallFact = SmallFact(20);
                List<byte> resultNum = new List<byte>();

                while (smallFact > 0)
                {
                    resultNum.Add((byte)(smallFact % 10));
                    smallFact = smallFact / 10;
                }

                Factorial(n, resultNum);
                PrintList(resultNum);
            }
        }
        public static void Factorial(byte n, List<byte> initialNum)
        {
            for (byte i = 21; i <= n; i++)
            {
                byte num1 = 0;
                byte num2 = 0;

                if (i % 10 == 0)
                {
                    initialNum.Insert(0, 0);
                    MultiplyMegaLongNum(initialNum, (byte)(i / 10));
                }
                else
                {
                    num1 = (byte)(i % 10);
                    num2 = (byte)(i / 10);

                    List<byte> additionalNum = new List<byte>(initialNum);
                    additionalNum.Insert(0, 0);
                    MultiplyMegaLongNum(initialNum, num1);
                    MultiplyMegaLongNum(additionalNum, num2);
                    SumGigaLongNumsWithSecondNumOffsat(initialNum, additionalNum);
                } 
            }
        }
        public static long SmallFact(byte n)
        {
            long smallFact = 1;
            for (byte i = 1; i <= n; i++)
            {
                smallFact = smallFact * i;
            }
            return smallFact;
        } 
        public static void MultiplyMegaLongNum(List<byte> num, byte n)
        {
            byte ostatyk = 0;
            byte temp = 0;

            for (byte j = 0; j <= num.Count - 1; j++)
            {
                bool overTen = false;
                temp = num[j];
                if ((j == num.Count - 1) && ((byte)(ostatyk + temp * n) >= 10))
                {
                    overTen = true;
                }
                num[j] = (byte)((ostatyk + temp * n) % 10);
                ostatyk = (byte)((ostatyk + temp * n) / 10);

                if (j == num.Count - 1 && ostatyk != 0 && overTen)
                {
                    num.Add(ostatyk);
                    break;
                }
            }
        }
        public static void SumGigaLongNumsWithSecondNumOffsat(List<byte> firstNum, List<byte> secondNum)
        {
            byte ostatyk = 0;
            byte tempfirst = 0;
            if (firstNum.Count == secondNum.Count)
            {
                for (byte i = 0; i <= firstNum.Count - 1; i++)
                {
                    tempfirst = firstNum[i];
                    firstNum[i] = ((byte)((firstNum[i] + secondNum[i] + ostatyk) % 10));
                    ostatyk = (byte)((tempfirst + secondNum[i] + ostatyk) / 10);
                }
                if (ostatyk != 0)
                {
                    firstNum.Add(ostatyk);
                }
            }
            else if (secondNum.Count > firstNum.Count)
            {
                for (byte i = 0; i <= firstNum.Count - 1; i++)
                {
                    tempfirst = firstNum[i];
                    firstNum[i] = (byte)((tempfirst + secondNum[i] + ostatyk) % 10);
                    ostatyk = (byte)((tempfirst + secondNum[i] + ostatyk) / 10);
                }

                byte firstNumLength = (byte)firstNum.Count;
                for (int i = 1; i <= secondNum.Count - firstNumLength; i++)
                {
                    firstNum.Add((byte)((secondNum[firstNumLength + i - 1] + ostatyk) % 10));
                    ostatyk = (byte)((secondNum[firstNumLength + i - 1] + ostatyk) / 10);

                }
                if (ostatyk != 0)
                {
                    firstNum.Add(ostatyk);
                }
            }
            else
            {
                for (byte i = 0; i <= secondNum.Count - 1; i++)
                {
                    tempfirst = firstNum[i];
                    firstNum[i] = ((byte)((firstNum[i] + secondNum[i] + ostatyk) % 10));
                    ostatyk = (byte)((tempfirst + secondNum[i] + ostatyk) / 10);
                }
                for (int i = 1; i <= firstNum.Count - secondNum.Count; i++)
                {
                    firstNum[i + (secondNum.Count)] = ((byte)((firstNum[i + (secondNum.Count)] + ostatyk) % 10));
                    ostatyk = (byte)((secondNum[firstNum.Count + i] + ostatyk) / 10);
                }
                if (ostatyk != 0)
                {
                    firstNum.Add(ostatyk);
                }
            }
            

        }
        public static void PrintList(List<byte> printMe)
        {
            for (byte i = 0; i <= printMe.Count - 1; i++)
            {
                Console.Write(printMe[printMe.Count - 1 - i]);
            }
        }
    }
}