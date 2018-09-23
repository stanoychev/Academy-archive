using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string status = "Correct";
            List<char> storage = new List<char>();

            for (int i = 0; i <= input.Length-1; i++)
            {
                if (input[i]=='(' || input[i] == ')')
                {
                    storage.Add(input[i]);
                }
            }

            int open = 0;
            int closed = 0;

            for (int i = 0; i <= storage.Count-1; i++)
            {
                if (storage[i]=='(')
                {
                    open++;
                }
                else
                {
                    closed++;
                }
                if (closed>open)
                {
                    break;
                }
            }

            if (

                open != closed ||
                storage.Count == 0

                )
            {
                status = "Incorrect";
            }

            Console.WriteLine(status);
        }
    }
}
