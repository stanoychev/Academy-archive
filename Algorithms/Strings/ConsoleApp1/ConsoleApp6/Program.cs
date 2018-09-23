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
            string word = Console.ReadLine();
            string text = Console.ReadLine();
            string[] sentences = text.Split(new string[] { ". ", "." }, StringSplitOptions.RemoveEmptyEntries);
            
            StringBuilder sentenceBuilder = new StringBuilder();
            StringBuilder wordBuilder = new StringBuilder();
            foreach (string sentence in sentences)
            {
                bool addSentence = false;
                int i = 0;
                while (i<=sentence.Length-1)
                {
                    if (IsLetter(sentence[i]))
                    {
                        wordBuilder.Append(sentence[i]);
                        while (i+1 <= sentence.Length-1 && IsLetter(sentence[i+1]))
                        {
                            i++;
                            wordBuilder.Append(sentence[i]);
                        }
                    }
                    if (wordBuilder.ToString()==word)
                    {
                        addSentence = true;
                        wordBuilder.Clear();
                        break;
                    }
                    wordBuilder.Clear();
                    i++;
                }
                if (addSentence)
                {
                    sentenceBuilder.Append(string.Format("{0}{1}", sentence, ". "));
                }
            }
            sentenceBuilder.Remove(sentenceBuilder.Length - 1, 1);            
            Console.WriteLine(sentenceBuilder.ToString());
        }

        public static bool IsLetter(char charahter)
        {
            //if ((charahter >= 48 && charahter <= 57)||(charahter >= 65 && charahter <= 90) || (charahter >= 97 && charahter <= 122))
            //in
            //45in. in 4353. 34 in. ini
            //in 4353. 34 in. inin in.
            if ((charahter >= 65 && charahter <= 90) || (charahter >= 97 && charahter <= 122))
            //in
            //45in. in 4353. 34 in. inin in.
            //45in. in 4353. 34 in. inin in.
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
