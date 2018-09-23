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

            if (n >= 1 && n <= 20)
            {
                Console.WriteLine(SmallFact(n));
            }
            else if (n >= 21 && n <= 99)
            {
                long smallFact = SmallFact(20);
                List<byte> resultNum = new List<byte>();

                while (smallFact > 0)
                {
                    resultNum.Add((byte)(smallFact % 10));
                    smallFact = smallFact / 10;
                } //fukin works

                Factorial(n, resultNum);
                //Console.WriteLine("Finalno");
                PrintList(resultNum);
            }
            else
            {
                n = 99;

                long smallFact = SmallFact(20);
                List<byte> resultNum = new List<byte>();

                while (smallFact > 0)
                {
                    resultNum.Add((byte)(smallFact % 10));
                    smallFact = smallFact / 10;
                } //fukin works

                Factorial(n, resultNum);
                PrintList(resultNum); //to tva e kraq deto imam predvid
                Console.Write("00"); // ili na kraq ili v nachaloto
            }

        }
        public static void Factorial(byte n, List<byte> initialNum) //initialNum-a e podaden list s 20!
        {
            for (byte i = 21; i <= n; i++)
            {
                byte num1 = 0;
                byte num2 = 0;

                if (i % 10 == 0) //go oprava
                {
                    initialNum.Insert(0,0);
                    MultiplyMegaLongNum(initialNum, (byte)(i / 10));
                } //tva e za 20! 30! 40! ...
                else
                {
                    num1 = (byte)(i % 10); // 21 -> 1
                    num2 = (byte)(i / 10); // 21 -> 2

                    List<byte> additionalNum = new List<byte>(initialNum); //list clone
                    additionalNum.Insert(0, 0);
                    // additionalNum = initialNum; //list clone, old methood, probably doesnt work

                    MultiplyMegaLongNum(initialNum, num1);
                    //Console.WriteLine("initialNum");
                    //PrintList(initialNum);
                    //Console.WriteLine();
                    MultiplyMegaLongNum(additionalNum, num2);
                    //Console.WriteLine("additionalNum");
                    //PrintList(additionalNum);
                    //Console.WriteLine();
                    
                    SumGigaLongNumsWithSecondNumOffsat(initialNum, additionalNum); //sumni gi i gi zapi6i v initialNum-a
                    

                } //tva e za vsi4ki drugi 4isla
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
        } //raboti
        public static void MultiplyMegaLongNum(List<byte> num, byte n)
        {
            byte ostatyk = 0;
            byte temp = 0;
            
            for (byte j = 0; j <= num.Count - 1; j++)
            {
                bool overTen = false;
                temp = num[j];
                if ((j== num.Count - 1) && ((byte)(ostatyk + temp*n)>=10) )
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

        } // izglevda da raboti // e sa ve4e raboti
        public static void SumGigaLongNumsWithSecondNumOffsat(List<byte> firstNum, List<byte> secondNum)
        {
            //createvam prazen result, deto na kraq 6te go izsipq v initial-a
            byte ostatyk = 0;
            byte tempfirst = 0; //tova se pravi za6toto sled sledwa6tiq red ostatyka zima nqkvo novo 4islo firstNum[i]
            if (firstNum.Count == secondNum.Count)     //var 1,
            {
               // Console.WriteLine("var1");
                for (byte i = 0; i <= firstNum.Count - 1; i++)
                {
                    tempfirst = firstNum[i]; //tova se pravi za6toto sled sledwa6tiq red ostatyka zima nqkvo novo 4islo firstNum[i]
                    firstNum[i] = ((byte)((firstNum[i] + secondNum[i] + ostatyk) % 10));
                    ostatyk = (byte)((tempfirst + secondNum[i] + ostatyk) / 10);
                }
                if (ostatyk != 0)
                {
                    firstNum.Add(ostatyk);
                }
            } //tva trea da raboti
            else if (secondNum.Count > firstNum.Count)  //var 2, raboti
            {
                
                //Console.WriteLine("var2");
                //PrintList(firstNum);
                //Console.WriteLine();
                for (byte i = 0; i <= firstNum.Count - 1; i++)
                {
                    tempfirst = firstNum[i]; //tova se pravi za6toto sled sledwa6tiq red ostatyka zima nqkvo novo 4islo firstNum[i]
                    firstNum[i] = (byte)((tempfirst + secondNum[i] + ostatyk) % 10);
                    ostatyk = (byte)((tempfirst + secondNum[i] + ostatyk) / 10);
                }
                
                byte firstNumLength = (byte)firstNum.Count;   //19  //poneje dobavqm kym firstNum List-a razmeryt mu se uveli4ava i za tova pravq stati4en razmer na firstNum
                for (int i = 1; i <= secondNum.Count - firstNumLength; i++) //13 - 10 = 3 => 1,2,3 // 20 - 19 = 1 => 1
                {
                    firstNum.Add((byte)((secondNum[firstNumLength + i - 1] + ostatyk) % 10)); //10 + i => 11,12,13 // 19 + 1 = 20 out => -1 = 19 = in
                    ostatyk = (byte)((secondNum[firstNumLength + i - 1] + ostatyk) / 10);
                    
                }

                if (ostatyk != 0)
                {
                    firstNum.Add(ostatyk);
                }

                //Console.WriteLine("end of var 2");
                //PrintList(firstNum);
                //Console.WriteLine();
            } //raboti drug pyt // sega raboti
            else if (secondNum.Count < firstNum.Count)   //var 3, 
            {
                //Console.WriteLine("var3");
                for (byte i = 0; i <= secondNum.Count - 1; i++)
                {
                    tempfirst = firstNum[i]; //tova se pravi za6toto sled sledwa6tiq red ostatyka zima nqkvo novo 4islo firstNum[i]
                    firstNum[i] = ((byte)((firstNum[i] + secondNum[i] + ostatyk) % 10));
                    ostatyk = (byte)((tempfirst + secondNum[i] + ostatyk) / 10);
                }
                for (int i = 1; i <= firstNum.Count - secondNum.Count; i++) // 10 - 7 = 3 => 1,2,3
                {
                    firstNum[i + (secondNum.Count)] = ((byte)((firstNum[i + (secondNum.Count)] + ostatyk) % 10)); // 1 + 7 = 8
                    ostatyk = (byte)((secondNum[firstNum.Count + i] + ostatyk) / 10);
                }
                if (ostatyk != 0)
                {
                    firstNum.Add(ostatyk);
                }
            }
            else
            {
                Console.WriteLine("kvo stava tuka ue");
            }
            
        }
        public static void PrintList(List<byte> printMe)
        {
            for (byte i = 0; i <= printMe.Count - 1; i++)
            {
                Console.Write(printMe[printMe.Count - 1-i]);
            }
        } //raboti
    }
}
//long itterations = long.Parse(Console.ReadLine());

//if (itterations <= 255)
//{
//byte n = (byte)itterations;
//}
//else if (itterations && itterations)
//{
//int n = (int)itterations;
//}

//if (n >= 1 && n <= 20)
//{
//Console.WriteLine(SmallFact(n));
//}
//else
//{
//List<byte> resultNum = new List<byte>();
//FactorialFrom21to255(resultNum, n);

//PrintList(resultNum); //to tva e kraq deto imam predvid
//}