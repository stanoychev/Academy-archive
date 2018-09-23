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
            BigList<Player> ranklist = new BigList<Player>();
            Dictionary<string, OrderedSet<Player>> playerTypeContayner = new Dictionary<string, OrderedSet<Player>>();
            string command;
            while ((command= Console.ReadLine()) != "end")
            {
                string[] subcommand = command.Split();

                switch (subcommand[0])
                {
                    case "add":
                        {
                            string name = subcommand[1];
                            string type = subcommand[2];
                            int age = int.Parse(subcommand[3]);
                            int position = int.Parse(subcommand[4])-1;

                            Player newPlayer = new Player();
                            newPlayer.Name = name;
                            newPlayer.Type = type;
                            newPlayer.Age = age;
                            
                            if (!playerTypeContayner.ContainsKey(type))
                            {
                                playerTypeContayner.Add(type, new OrderedSet<Player>());
                            }

                            playerTypeContayner[type].Add(newPlayer);
                            ranklist.Insert(position, newPlayer);

                            Console.WriteLine(string.Format("Added player {0} to position {1}", newPlayer.Name, position+1));
                            break;
                        }
                    case "find":
                        {   
                            string type = subcommand[1];

                            if (playerTypeContayner.ContainsKey(type))
                            {
                                var displayPlayers = playerTypeContayner[type];

                                string result = string.Format("Type {0}: {1}", type, string.Join("; ", displayPlayers.Take(5)));

                                //result.TrimEnd(';', ' ');

                                Console.WriteLine(result); 
                            }
                            else
                            {
                                Console.WriteLine("Type {0}: ", type);
                            }
                            break;
                        }
                    case "ranklist":
                        {
                            int start = int.Parse(subcommand[1])-1;
                            int end = int.Parse(subcommand[2])-1;
                            var listToDisplay = ranklist.Range(start, end - start + 1);
                            int counter = start+1;

                            string result = string.Join("; ", listToDisplay.Select(x => string.Format("{0}. {1}", counter++ ,x.ToString())));
                            
                            Console.WriteLine(result);

                            break;
                        }
                }
            }
        }
    }
    public class Player : IComparable <Player>
    {
        public string Name
        {
            get; set;
        }

        public string Type
        {
            get; set;
        }

        public int Age
        {
            get; set;
        }


        public int CompareTo(Player other)
        {
            if (this.Name.CompareTo(other.Name) != 0)
            {
                return this.Name.CompareTo((other).Name);
            }
            else
            {
                return this.Age.CompareTo((other).Age)*-1;
            }
        }

        public override string ToString()
        {
            return string.Format("{0}({1})", this.Name, this.Age);
        }
    }

}
