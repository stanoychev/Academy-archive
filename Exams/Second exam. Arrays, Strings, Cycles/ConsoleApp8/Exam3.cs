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
            List<string> ContainerWithVariables = new List<string>();
            StringBuilder variable = new StringBuilder();

            bool multiCommentOpen = false;
            
            while (text != "{!}")
            {
                for (int i = 0; i <= text.Length - 1; i++)
                {
                    if ((i + 1) <= text.Length - 1
                        &&
                        text[i] == '/'
                        &&
                        text[i + 1] == '/') //singleline comment
                    {
                        break;
                    }//raboti, ne go pipam
                    if (text[i] == '#') //singleline comment
                    {
                        break;
                    }//raboti, ne go pipam

                    if ((i + 1) <= text.Length - 1
                        &&
                        text[i] == '/'
                        &&
                        text[i + 1] == '*') //multiline comment open
                    {
                        multiCommentOpen = true;
                    }//raboti, ne go pipam

                    if ((i + 1) <= text.Length - 1
                        &&
                        text[i] == '*'
                        &&
                        text[i + 1] == '/') //multiline comment closed
                    {
                        multiCommentOpen = false;
                    }//raboti, ne go pipam
                    
                    if (i - 1 >= 0
                        &&
                        text[i - 1].ToString() == @"\") //tova e da se ignorira dumata ako e v string i pred neq ima \
                    {
                        i++;
                    }

                    if (multiCommentOpen == false)
                    {
                        if (text[i] == '@'
                            &&
                            (i + 1 <= text.Length - 1)
                            &&
                            (text[i + 1] == '_' // '_'
                            ||
                            (text[i + 1] >= 65 && text[i + 1] <= 90) // golemi bukvi
                            ||
                            (text[i + 1] >= 97 && text[i + 1] <= 122))) // malki bukvi
                        {
                            for (int j = i + 1;
                                j <= text.Length - 1
                                &&
                                ((text[j] == '_' // '_'
                                ||
                                (text[j] >= 65 && text[j] <= 90) // golemi bukvi
                                ||
                                (text[j] >= 97 && text[j] <= 122) // malki bukvi
                                ||
                                (text[j] >= 48 && text[j] <= 57))); //cifri
                                j++) //variable Builder-a
                            {
                                variable.Append(text[j]);
                                i = j;
                            }

                            if (ContainerWithVariables.Contains(variable.ToString()) == false)
                            {
                                ContainerWithVariables.Add(variable.ToString());
                            }
                            variable.Clear();
                        }
                    }
                }
                text = Console.ReadLine();
            }

            Console.WriteLine(ContainerWithVariables.Count);
            for (int i = 0; i <= ContainerWithVariables.Count - 1; i++)
            {
                Console.WriteLine(ContainerWithVariables[i]);
            }

        }
    }
}