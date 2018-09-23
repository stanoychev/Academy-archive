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
            Dictionary<string, OrderedBag<Order>> ordersByName = new Dictionary<string, OrderedBag<Order>>();
            OrderedDictionary<decimal, List<Order>> sortedByPrice = new OrderedDictionary<decimal, List<Order>>();

            string command;
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i <= n - 1; i++)
            {
                command = Console.ReadLine();
                string[] splittedCommand = command.Split();
                string[] commandParameters = string.Join(" ", splittedCommand.Skip(1)).Split(';');
                switch (splittedCommand[0])
                {
                    case "AddOrder":
                        {
                            string name = commandParameters[0];
                            decimal price = decimal.Parse(commandParameters[1]);
                            string consumer = commandParameters[2];

                            Order order = new Order();
                            order.Name = name;
                            order.Price = price;
                            order.Consumer = consumer;

                            if (!ordersByName.ContainsKey(consumer))
                            {
                                ordersByName.Add(consumer, new OrderedBag<Order> { order });
                            }
                            else
                            {
                                ordersByName[consumer].Add(order);
                            }

                            if (!sortedByPrice.ContainsKey(price))
                            {
                                sortedByPrice.Add(price, new List<Order> { order });
                            }
                            else
                            {
                                sortedByPrice[price].Add(order);
                            }

                            Console.WriteLine("Order added");
                            break;
                        }
                    case "DeleteOrders":
                        {
                            string consumer = commandParameters[0];

                            if (ordersByName.ContainsKey(consumer))
                            {
                                int x = ordersByName[consumer].Count;
                                ordersByName.Remove(consumer);

                                foreach (KeyValuePair<decimal, List<Order>> item in sortedByPrice)
                                {
                                    item.Value.RemoveAll(y => y.Consumer == consumer);
                                }

                                Console.WriteLine("{0} orders deleted", x);
                            }
                            else
                            {
                                Console.WriteLine("No orders found");
                            }
                            break;
                        }
                    case "FindOrdersByPriceRange":
                        {
                            decimal fromPrice = decimal.Parse(commandParameters[0]);
                            decimal toPrice = decimal.Parse(commandParameters[1]);
                            StringBuilder builder = new StringBuilder();
                            OrderedBag<Order> temp = new OrderedBag<Order>();

                            foreach (var item in sortedByPrice.Range(fromPrice, true, toPrice, true))
                            {
                                temp.AddMany(item.Value);
                            }

                            builder.Append(string.Join("\n", temp));

                            if (builder.Length == 0)
                            {
                                Console.WriteLine("No orders found");
                            }
                            else
                            {
                                Console.WriteLine(builder.ToString());
                            }
                            break;
                        }
                    case "FindOrdersByConsumer":
                        {
                            string consumer = commandParameters[0];
                            StringBuilder builder = new StringBuilder();
                            if (ordersByName.ContainsKey(consumer))
                            {
                                foreach (var order in ordersByName[consumer])
                                {
                                    builder.Append(string.Format("{0}\n", order.ToString()));
                                }
                            }
                            else
                            {
                                builder.Append("No orders found\n");
                            }
                            Console.WriteLine(builder.ToString().Remove(builder.Length - 1, 1));
                            break;
                        }
                }
            }
        }
    }
    public class Order : IComparable<Order>
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Consumer { get; set; }

        public int CompareTo(Order other)
        {
            return this.Name.CompareTo(other.Name);
        }

        public override string ToString()
        {
            return string.Format("{{{0};{1};{2:0.00}}}", this.Name, this.Consumer, this.Price);
        }
    }
}
