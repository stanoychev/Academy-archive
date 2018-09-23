using System;
using System.Text;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();
            StringBuilder stringBuilder = new StringBuilder();
            char initial = input[0];
            stringBuilder.Append(initial);

            for (int i = 1; i <=input.Length-1; i++)
            {
                if (initial != input[i])
                {
                    stringBuilder.Append(input[i]);
                    initial = input[i];
                }
            }
            Console.WriteLine(stringBuilder.ToString());
        }
    }
}
