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
            string pattern = Console.ReadLine().ToLower();
            string text = Console.ReadLine().ToLower();
            int max = 0;
            for (int i = 0; i <= text.Length-1; i++)
            {
                if (text[i]==pattern[0])
                {
                    bool ding = true;
                    for (int j = 1; j <=pattern.Length-1; j++)
                    {
                        if (i + j <= text.Length - 1)
                        {
                            if (text[i + j] != pattern[j])
                            {
                                ding = false;
                            }
                        }
                        else
                        {
                            ding = false;
                            break;
                        }
                    }
                    if (ding)
                    {
                        max++;
                    }
                }
            }
            Console.WriteLine(max);
        }
    }
}
