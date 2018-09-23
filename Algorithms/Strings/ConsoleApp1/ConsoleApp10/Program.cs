using System;
using System.Text;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            for (int i = 0; i <=input.Length-1; i++)
            {
                int num = Convert.ToInt32(input[i].ToString(), 16);
                Console.WriteLine(num);
                
            }

        }
    }
}
