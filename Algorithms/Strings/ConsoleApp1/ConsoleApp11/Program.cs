using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Rextester
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool check = false;
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string[] sentences = text.Split(new string[] { ". ", "." }, StringSplitOptions.RemoveEmptyEntries);

            List<char> symbols = new List<char>();
            for (int i = 32; i <= 64; i++) { symbols.Add((char)i); }
            for (int i = 91; i <= 96; i++) { symbols.Add((char)i); }
            for (int i = 123; i <= 126; i++) { symbols.Add((char)i); }

            StringBuilder builder = new StringBuilder();
            foreach (string sentence in sentences)
            {
                string[] fragmented = sentence.Split(symbols.ToArray(), StringSplitOptions.RemoveEmptyEntries);

                if (fragmented.Contains(word))
                {
                    string testsentence = sentence.TrimStart(symbols.ToArray());
                    char item = testsentence[0];
                    //if ((item >= 65 && item <= 90) || (item >= 97 && item <= 122))
                    if (item >= 48 && item <= 57)
                    {
                        check = true;
                    }
                    else
                    {

                    }

                    if (check)
                    {
                        throw new Exception();
                    }

                    builder.Append(string.Format("{0}{1}", sentence, ". "));


                }
            }

            builder.Remove(builder.Length - 1, 1);

            Console.WriteLine(builder.ToString());


        }
    }
}