using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Wintellect.PowerCollections;

namespace PlayerRanking
{
    class Program
    {
        static void Main(string[] args)
        {
            Deque<byte> deque = new Deque<byte>();

            string command;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n - 1; i++)
            {
                command = Console.ReadLine();
                string[] commandParameters = command.Split();
                switch (commandParameters[0])
                {
                    case "add":
                        {
                            byte iD = byte.Parse(commandParameters[1]);
                            deque.AddToBack(iD);
                            Console.WriteLine("Added {0}", iD);
                            break;
                        }
                    case "slide":
                        {
                            int k = int.Parse(commandParameters[1]);
                            byte tmp;
                            for (int j = 0; j <= k - 1; j++)
                            {
                                tmp = deque.RemoveFromFront();
                                deque.AddToBack(tmp);
                            }
                            Console.WriteLine("Slided {0}", k);
                            break;
                        }
                    case "print":
                        {
                            int size = deque.Count;
                            byte tmp;
                            StringBuilder pehso = new StringBuilder();
                            for (int j = size - 1; j >= 1; j--)
                            {
                                tmp = deque.RemoveFromBack();
                                deque.AddToFront(tmp);
                                pehso.Append(string.Format("{0} ", tmp));
                            }
                            if (size >= 1)
                            {
                                tmp = deque.RemoveFromBack();
                                deque.AddToFront(tmp);
                                pehso.Append(string.Format("{0}", tmp));
                            }
                            Console.WriteLine(pehso.ToString());
                            break;
                        }
                }
            }
        }
    }
}
