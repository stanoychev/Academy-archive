using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Wintellect.PowerCollections;

namespace ConsoleApp7
{
    class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Unit> units = new Dictionary<string, Unit>();

            OrderedBag<Unit> bagOfUnits = new OrderedBag<Unit>();

            Dictionary<string, OrderedBag<Unit>> unitsByUnittype = new Dictionary<string, OrderedBag<Unit>>();
            
            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] subcommand = command.Split();

                switch (subcommand[0])
                {
                    case "add":
                        {
                            string name = subcommand[1];
                            string type = subcommand[2];
                            int attack = int.Parse(subcommand[3]);

                            Unit unit = new Unit();
                            unit.Name = name;
                            unit.Type = type;
                            unit.Attack = attack;

                            if (units.ContainsKey(name))
                            {
                                Console.WriteLine("FAIL: {0} already exists!", name);
                            }
                            else
                            {
                                units.Add(name, unit);
                                bagOfUnits.Add(unit);

                                if (unitsByUnittype.ContainsKey(type))
                                {
                                    unitsByUnittype[type].Add(unit);
                                }
                                else
                                {
                                    unitsByUnittype.Add(type, new OrderedBag<Unit>() { unit });
                                }
                                
                                Console.WriteLine("SUCCESS: {0} added!", name);
                            }
                            break;
                        }
                    case "remove":
                        {
                            string name = subcommand[1];
                            if (units.ContainsKey(name))
                            {
                                var unitToDelete = units[name];
                                units.Remove(name);
                                bagOfUnits.Remove(unitToDelete);
                                unitsByUnittype[unitToDelete.Type].Remove(unitsByUnittype[unitToDelete.Type].First(x => x.Name == name));
                                
                                Console.WriteLine("SUCCESS: {0} removed!", name);
                            }
                            else
                            {
                                Console.WriteLine("FAIL: {0} could not be found!", name);
                            }
                            break;
                        }
                    case "find":
                        {
                            string type = subcommand[1];
                            StringBuilder builder = new StringBuilder();
                            builder.Append("RESULT: ");

                            if (unitsByUnittype.ContainsKey(type))
                            {
                                builder.Append(string.Join("", unitsByUnittype[type].Take(10)));
                            }
                            
                            if (builder[builder.Length - 2] == ',')
                            {
                                builder.Remove(builder.Length - 2, 2);
                            }
                            Console.WriteLine(builder.ToString());
                            break;
                        }
                    case "power":
                        {
                            int numberOfUnits = int.Parse(subcommand[1]);
                            StringBuilder builder = new StringBuilder();
                            builder.Append("RESULT: ");

                            builder.Append(string.Join("", bagOfUnits.Take(numberOfUnits)));

                            if (builder[builder.Length - 2] == ',')
                            {
                                builder.Remove(builder.Length - 2, 2);
                            }
                            Console.WriteLine(builder.ToString());
                            break;
                        }
                }
            }
        }

        public class Unit : IComparable<Unit>
        {
            public string Name { get; set; } //1 .. 30 //unique

            public string Type { get; set; } //1 .. 40 //not unique

            public int Attack { get; set; } //100 .. 1000 incl

            public int CompareTo(Unit otherUnit)
            {
                if (this.Attack.CompareTo(otherUnit.Attack) != 0)
                {
                    return this.Attack.CompareTo(otherUnit.Attack) * -1;
                }
                else
                {
                    return this.Name.CompareTo(otherUnit.Name);
                }
            }

            public override string ToString()
            {
                return string.Format("{0}[{1}]({2}), ", this.Name, this.Type, this.Attack);
            }
        }
    }
}
