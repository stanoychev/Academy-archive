using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Rextester
{
    public class SpellCaster
    {
        public static void Main(string[] args)
        {
            string initial = Console.ReadLine();
            string[] substring = initial.Split(' ');

            int biggestWord = 0;
            int totalLetterCount = 0;
            int[] lengths = new int[substring.GetLength(0)];

            for (int i = 0; i <= substring.GetLength(0) - 1; i++)
            {
                if (substring[i].Length > biggestWord) biggestWord = substring[i].Length;
                totalLetterCount += substring[i].Length;
                lengths[i] = substring[i].Length;
            }

            char[] word = new char[totalLetterCount]; // da napravq masiv ot charove 
            int index = 0;
            for (int i = 0; i <= biggestWord - 1; i++)
            {
                for (int j = 0; j <= substring.GetLength(0) - 1; j++) //j e indeks na dumata j=0 e nulevata duma
                {
                    if (lengths[j] > 0)
                    {
                        word[index] = substring[j][lengths[j] - 1];
                        index += 1;
                        lengths[j] -= 1;
                    }
                }
            } //end of task 1

            for (int i = 0; i <= totalLetterCount - 1; i++)
            {
                int alphabetNum = 0;
                if (word[i] <= 90) alphabetNum = (int)word[i] - 64; else alphabetNum = (int)word[i] - 96;
                int moveRight = alphabetNum % totalLetterCount;
                char tmp = (char)word[i];
                if (moveRight + i > totalLetterCount - 1)
                {
                    for (int j = 1; j <= totalLetterCount - moveRight; j++)
                    {
                        word[i - j + 1] = (char)word[i - j];
                    }
                    word[i - (totalLetterCount - moveRight)] = (char)tmp;
                }

                else
                {
                    for (int j = 1; j <= moveRight; j++)
                    {
                        word[i + j - 1] = (char)word[i + j];
                    }
                    word[i + moveRight] = (char)tmp;
                }
            }

            PrintArray(word); //print 
        }
        public static void PrintArray(char[] array)
        {
            for (int i = 0; i <= array.GetLength(0) - 1; i++)
            {
                Console.Write("{0}", array[i]);
            }
        }
    }
}