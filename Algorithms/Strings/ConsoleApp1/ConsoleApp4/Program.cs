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
            string text = Console.ReadLine();
            List<string> newText = new List<string>();
            
            string[] casechangers = new string[] { "<upcase>", "</upcase>" };
            string[] substring = text.Split(casechangers, StringSplitOptions.None);
            
            for (int i = 0; i <= substring.GetLength(0) - 1; i++)
            {
                if (i % 2 == 1)
                {
                    newText.Add(substring[i].ToUpper());
                }
                else
                {
                    newText.Add(substring[i]);
                }
            }

            Console.WriteLine(string.Join("", newText.ToArray()));
        }
    }
}
