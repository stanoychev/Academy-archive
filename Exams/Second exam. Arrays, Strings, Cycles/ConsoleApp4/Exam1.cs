using System;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            int result = ClculateRsult(input);
            
            if (result%10==0)
            {
                Console.WriteLine(result);
                Console.WriteLine("Big Vik wins again!");
            }
            else
            {
                Console.WriteLine(result);
                int messageLength = Math.Abs(result) % 10;
                int remeinder = result % 26;

                for (int i = 0; i <= messageLength - 1; i++) //za prevyrtaneto moje i letter = letter %27 ili okolo 27 n%m = 0 ... m-1
                {
                    int letter = remeinder +65 + i;
                    while (letter > 90)
                    {
                        letter = letter - 26;
                    }
                    while (letter < 65)
                    {
                        letter = letter + 26;
                    }
                    Console.Write((char)letter);
                }
            }
        }
        public static int ClculateRsult(string input)
        {
            int result = 0;
            int inputLength = input.Length;
            if (input[0]=='-')
            {
                inputLength--;
            }

            for (int i = 0; i <= inputLength - 1; i++)
            {
                if ((i + 1) % 2 == 0) //even
                {
                    result = result + (input[input.Length - 1 - i] - '0') * (input[input.Length - 1 - i] - 48) * (i + 1);
                }
                else //odd
                {
                    result = result + (input[input.Length - 1 - i] - 48) * (i + 1) * (i + 1);
                }
            }
            return result;
        }
    }
}

