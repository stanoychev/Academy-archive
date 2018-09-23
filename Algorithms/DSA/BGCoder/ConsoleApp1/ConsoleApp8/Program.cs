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
            Dictionary<string, Product> listByName = new Dictionary<string, Product>();

            Dictionary<string, OrderedBag<Product>> listFilteredByType = new Dictionary<string, OrderedBag<Product>>();

            OrderedBag<Product> allProducts = new OrderedBag<Product>();

            string command;
            while ((command = Console.ReadLine()) != "end")
            {
                string[] subcommand = command.Split();

                switch (subcommand[0])
                {
                    case "add":
                        {
                            string name = subcommand[1];
                            double price = double.Parse(subcommand[2]);
                            string type = subcommand[3];
                            
                            Product product = new Product();
                            product.Name = name;
                            product.Type = type;
                            product.Price = price;

                            if (listByName.ContainsKey(name))
                            {
                                Console.WriteLine("Error: Product {0} already exists", name);
                            }
                            else
                            {
                                listByName.Add(name, product);
                                if (listFilteredByType.ContainsKey(type))
                                {
                                    listFilteredByType[type].Add(product);
                                }
                                else
                                {
                                    listFilteredByType.Add(type, new OrderedBag<Product>() { product });
                                }
                                allProducts.Add(product);
                                Console.WriteLine("Ok: Product {0} added successfully", name);
                            }
                            break;
                        }
                    case "filter":
                        {
                            switch (subcommand[2])
                            {
                                case "type":
                                    {
                                        string type = subcommand[3];

                                        if (listFilteredByType.ContainsKey(type))
                                        {
                                            StringBuilder builder = new StringBuilder();
                                            builder.Append("Ok: ");
                                            builder.Append(string.Join("", listFilteredByType[type].Take(10)));
                                            if (builder[builder.Length-2]==',')
                                            {
                                                builder.Remove(builder.Length - 2, 2);
                                            }
                                            Console.WriteLine(builder.ToString());
                                        }
                                        else
                                        {
                                            Console.WriteLine("Error: Type {0} does not exists", type);
                                        }
                                        break;
                                    }
                                case "price":
                                    {
                                        StringBuilder builder = new StringBuilder();
                                        builder.Append("Ok: ");
                                        switch (subcommand[3])
                                        {
                                            case "from":
                                                {
                                                    double minPrice = double.Parse(subcommand[4]);

                                                    switch (subcommand.Length)
                                                    {
                                                        case 7:
                                                            {
                                                                double maxPrice = double.Parse(subcommand[6]);

                                                                builder.Append(string.Join("", allProducts.Where(x=> minPrice <= x.Price && x.Price <= maxPrice).Take(10)));
                                                            }
                                                            break;
                                                        case 5:
                                                            {
                                                                builder.Append(string.Join("", allProducts.Where(x => minPrice <= x.Price).Take(10)));
                                                            }
                                                            break;
                                                    }
                                                    break;
                                                }
                                            case "to":
                                                {
                                                    double maxPrice = double.Parse(subcommand[4]);

                                                    builder.Append(string.Join("", allProducts.Where(x => x.Price <= maxPrice).Take(10)));
                                                }
                                                break;
                                        }

                                        if (builder[builder.Length - 2] == ',')
                                        {
                                            builder.Remove(builder.Length - 2, 2);
                                        }
                                        Console.WriteLine(builder.ToString());

                                        break;
                                    }
                            }
                            break;
                        }
                }
            }
        }

        public class Product : IComparable<Product>
        {
            public string Name { get; set; }

            public string Type { get; set; }

            public double Price { get; set; }
            
            public int CompareTo(Product otherProduct)
            {
                if (this.Price.CompareTo(otherProduct.Price) != 0)
                {
                    return this.Price.CompareTo(otherProduct.Price);
                }
                else
                {
                    if (this.Name.CompareTo(otherProduct.Name) != 0)
                    {
                        return this.Name.CompareTo(otherProduct.Name);
                    }
                    else
                    {
                        return this.Type.CompareTo(otherProduct.Type);
                    }
                }
            }

            public override string ToString()
            {
                return string.Format("{0}({1}), ", this.Name, this.Price);
            }
        }
    }
}
