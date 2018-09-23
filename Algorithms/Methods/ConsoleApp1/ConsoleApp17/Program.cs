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
                for (byte i = 0; i <= smallFact.ToString().Length - 1; i++)
                {
                    resultNum.Add((byte)smallFact.ToString()[smallFact.ToString().Length - 1 - i]);
                } //tuka da proverq kak se podavat 4islata otpred nazad ili obratno

                Factorial(n, resultNum);
               // PrintList(resultNum);
            }
            else
            {
                n = 99;

                long smallFact = SmallFact(20);
                List<byte> resultNum = new List<byte>();
                for (byte i = 0; i <= smallFact.ToString().Length - 1; i++)
                {
                    resultNum.Add((byte)smallFact.ToString()[smallFact.ToString().Length - 1 - i]);
                } //tuka da proverq kak se podavat 4islata otpred nazad ili obratno
                Factorial(n, resultNum);
                Console.Write("00"); // ili na kraq
              //  PrintList(resultNum);
            }

        }
        public static void Factorial(byte n, List<byte> initialNum) //initialNum-a e podaden list s 20!
        {
            for (byte i = 21; i <= n; i++)
            {
                byte num1 = 0;
                byte num2 = 0;

                if (i % 10 == 0)
                {
                    initialNum.Add(0); // vnimavai kyde e taq nula!!! mai e ne kydeto iskam
                    MultiplyMegaLongNum(initialNum, i);
                } // tva e za 20! 30! 40! ...
                else
                {
                    num1 = (byte)(i % 10); // 21 -> 1
                    num2 = (byte)(i / 10); // 21 -> 2

                    List<byte> additionalNum = new List<byte>(initialNum); //list clone

                    // additionalNum = initialNum; //list clone, old methood, probably doesnt work

                    MultiplyMegaLongNum(initialNum, num1);

                    MultiplyMegaLongNum(additionalNum, num2);

                    List<byte> resultNum = new List<byte>();

                    SumGigaLongNumsWithSecondNumOffsat(initialNum, additionalNum, resultNum); //sumni gi i gi zapi6i v initialNum-a
                    initialNum.Clear();
                    //CloneList(initialNum, resultNum);
                    initialNum = resultNum; //tva ako ne dade eror te pa na za vseki slu4ai gornoto da go izdefiniram

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
            for (byte j = 0; j <= num.Count - 1; j++)
            {
                num[j] = (byte)((ostatyk + num[j] * (n / 10)) % 10);
                ostatyk = (byte)((ostatyk + num[j] * (n / 10)) / 10);

                if (j == num.Count - 1 && ostatyk != 0)
                {
                    num.Add(ostatyk); //vnimavai kyde se dobavq tva
                }
            }
        } // izglevda da raboti
        public static void SumGigaLongNumsWithSecondNumOffsat(List<byte> firstNum, List<byte> secondNum, List<byte> resultNum)
        {
            //createvam prazen result, deto na kraq 6te go izsipq v initial-a
            byte ostatyk = 0;

            resultNum.Add(firstNum[0]);
            
            if (firstNum.Count-1 == secondNum.Count)     //var 1,
            {
                Console.WriteLine(1);
                //for (byte i = 0; i <= secondNum.Count - 1; i++)
                //{
                    //resultNum.Add((byte)((firstNum[i + 1] + secondNum[i] + ostatyk) % 10));
                    //ostatyk = (byte)((firstNum[i + 1] + secondNum[i] + ostatyk) / 10);
                //}
                //if (ostatyk != 0)
                //{
                    //resultNum.Add(ostatyk);
                //}
            } //tva trea da raboti
            else if (secondNum.Count >= firstNum.Count)  //var 2,
            {
                Console.WriteLine(2);
                //for (byte i = 0; i <= firstNum.Count - 2; i++)
                //{
                    //resultNum.Add((byte)((firstNum[i + 1] + secondNum[i] + ostatyk) % 10));
                    //ostatyk = (byte)((firstNum[i + 1] + secondNum[i] + ostatyk) / 10);
                //}
                //for (int i = 0; i <=secondNum.Count-firstNum.Count; i++) //12 - 10 = 2 => 0,1,2 // 10 - 10 = 0 => 0
                //{
                    //resultNum.Add((byte)((secondNum[firstNum.Count + i] + ostatyk) % 10)); //10 + i => 10,11,12
                    //ostatyk = (byte)((secondNum[firstNum.Count + i] + ostatyk) % 10);
                //}
                //if (ostatyk != 0)
                //{
                    //resultNum.Add(ostatyk);
                //}
            } //gospodi, mola te
            else if (secondNum.Count < firstNum.Count)   //var 3, 
            {
                Console.WriteLine(3);
                //for (byte i = 0; i <= secondNum.Count - 1; i++)
                //{
                    //resultNum.Add((byte)((firstNum[i + 1] + secondNum[i] + ostatyk) % 10));
                    //ostatyk = (byte)((firstNum[i + 1] + secondNum[i] + ostatyk) / 10);
                //}
                //for (int i = 0; i <= firstNum.Count - secondNum.Count-2; i++) //10-6-2 = 2 => 0,1,2
                //{
                    //resultNum.Add((byte)((firstNum[secondNum.Count+1 + i] + ostatyk) % 10)); //6+1 + i => 7,8,9
                    //ostatyk = (byte)((secondNum[firstNum.Count + i] + ostatyk) % 10);
                //}
                //if (ostatyk != 0)
                //{
                    //resultNum.Add(ostatyk);
                //}
            }
            else
            {
                Console.WriteLine(4);
                //throw new Exception();
            }
            
            //tuka sa trqbva initial num da zeme resultnym ili da se zamesti napravo. ne tva go pravq gore v glavniq metod, toq vry6ta sumiran resultNum





        }
        public static void PrintList(List<byte> printMe)
        {
            for (byte i = 0; i <= printMe.Count - 1; i++)
            {
                Console.Write(printMe[i]);
            }
        } //raboti
    }
}