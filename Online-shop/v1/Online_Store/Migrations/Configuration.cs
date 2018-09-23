using Newtonsoft.Json;
using Online_Store.Models;
using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace Online_Store.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Online_Store.Data.StoreContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(Online_Store.Data.StoreContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            try
            {
                using (StreamReader usersStream = new StreamReader(@"../../../json/Users.json"))
                {
                    IList<User> users = JsonConvert.DeserializeObject<IList<User>>(usersStream.ReadToEnd());

                    for (int i = 0; i <= users.Count - 1; i++)
                    {
                        if (i % 2 == 0)
                        {
                            User user = users[i];
                            user.Seller = new Seller();
                            if (!context.Users.Any(x => x.Username == user.Username))
                            {
                                context.Users.Add(user);
                            }
                        }
                        else
                        {
                            User user = users[i];
                            if (!context.Users.Any(x => x.Username == user.Username))
                            {
                                context.Users.Add(users[i]);
                            }
                        }
                    }
                    context.SaveChanges();
                    //Console.WriteLine("User added succesfully.");
                }
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the users from Users.json");
            }

            try
            {
                using (StreamReader r = new StreamReader(@"../../../json/User.json"))
                {
                    if (!context.Users.Any())
                    {
                        string json = r.ReadToEnd();
                        var user = JsonConvert.DeserializeObject<User>(json);
                        user.Seller = new Seller();
                        user.Cart = new Cart();
                        context.Users.Add(user);
                        context.SaveChanges();
                        //Console.WriteLine("One more user added succesfully.");
                    }
                }
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the user from User.json.");
            }

            try
            {
                if (context.Carts.ToList().Count == 0)
                {
                    context.Carts.Add(new Cart() { UserId = context.Users.First().Id }); //only exceptionless way for now to add a cart
                    context.SaveChanges();
                    //Console.WriteLine("A cart added succesfully.");
                } //to try to foreach each
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the cart.");
            }

            try
            {
                using (StreamReader productsStream = new StreamReader(@"../../../json/Products.json"))
                {
                    if (context.Products.Count() == 0)
                    {
                        IList<Product> products = JsonConvert.DeserializeObject<IList<Product>>(productsStream.ReadToEnd());

                        IList<Seller> sellerCollection = context.Sellers.Take(3).ToList();

                        for (int i = 0; i <= 2; i++)
                        {
                            products[i].Seller = sellerCollection[i];
                            context.Products.Add(products[i]);
                        }
                    }
                    context.SaveChanges();
                    //Console.WriteLine("Products added succesfully.");
                }
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the products from Products.json");
            }

            try
            {
                using (StreamReader reader = new StreamReader(@"../../../json/Feedback.json"))
                {
                    if (!context.Feedbacks.Any()) //v momenta se vika nikoga
                    {
                        string json = reader.ReadToEnd();
                        var feedback = JsonConvert.DeserializeObject<Feedback>(json);
                        context.Feedbacks.Add(feedback);
                        context.SaveChanges();
                        //Console.WriteLine("Feedbacks added succesfully.");
                    }

                }
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the feedbacks from Feedback.json");
            }

            try
            {
                using (StreamReader reader = new StreamReader(@"../../../json/ShippingDetails.json"))
                {
                    if (!context.ShippingDetails.Any()) //v momenta se vika nikoga
                    {
                        string json = reader.ReadToEnd();
                        var shippingDetails = JsonConvert.DeserializeObject<ShippingDetails>(json);
                        context.ShippingDetails.Add(shippingDetails);
                        context.SaveChanges();
                        //Console.WriteLine("Shipping details added succesfully.");
                    }
                }
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the shipping details from ShippingDetails.json");
            }

            try
            {
                using (StreamReader reader = new StreamReader(@"../../../xml/users.xml"))
                {
                    var xmlUsers = XElement.Load(reader);

                    var users = xmlUsers.Elements("user").Select(x =>
                    {
                        return new User()
                        {
                            Username = x.Element("username").Value,
                            Password = x.Element("password").Value
                        };
                    });

                    foreach (User user in users)
                    {
                        if (!context.Users.Any(x => x.Username == user.Username))
                        {
                            context.Users.Add(user);
                        }
                    }
                    context.SaveChanges();
                    //Console.WriteLine("Even more users added succesfully.");
                }
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the users from users.xml");
            }

            try
            {
                using (StreamReader reader = new StreamReader(@"../../../xml/products.xml"))
                {
                    var xmlUsers = XElement.Load(reader);

                    var products = xmlUsers.Elements("product").Select(x =>
                    {
                        return new Product()
                        {
                            SellerId = context.Sellers.First().UserId,
                            ProductName = x.Element("ProductName").Value,
                            Price = decimal.Parse(x.Element("Price").Value),
                            Date = DateTime.Now,
                            PaymentMethod = (PaymentMethodEnum)Enum.Parse(typeof(PaymentMethodEnum), x.Element("PaymentMethod").Value, true),
                            Sale = new Sale()
                            {
                                PriceReduction = decimal.Parse(x.Element("Sale").Element("PriceReduction").Value)
                            },
                            ShippingDetails = new ShippingDetails()
                            {
                                DeliveryTime = int.Parse(x.Element("ShippingDetails").Element("DeliveryTime").Value),
                                Cost = decimal.Parse(x.Element("ShippingDetails").Element("Cost").Value)
                            },
                            Instock = bool.Parse(x.Element("Instock").Value),
                            Categories = new List<Category>()
                        {
                            new Category()
                            {
                                CategoryName = x.Elements("Categories").First().Element("CategoryName").Value
                            },
                            new Category()
                            {
                                CategoryName = x.Elements("Categories").Last().Element("CategoryName").Value
                            }
                        },
                            Feedbacks = new List<Feedback>()
                        {
                            new Feedback()
                            {
                                Comment = x.Elements("Feedbacks").First().Element("Comment").Value,
                                Rating = int.Parse(x.Elements("Feedbacks").First().Element("Rating").Value),
                                Date = DateTime.Now,
                                SellerId = context.Sellers.First().UserId,
                            },
                            new Feedback()
                            {
                                Comment = x.Elements("Feedbacks").Last().Element("Comment").Value,
                                Date = DateTime.Now,
                                SellerId = context.Sellers.First().UserId,
                            }
                        }

                        };
                    });

                    foreach (Product product in products)
                    {
                        if (!context.Products.Any(x => x.ProductName == product.ProductName))
                        {
                            context.Products.Add(product);
                        }
                    }
                    context.SaveChanges();
                    //Console.WriteLine("Even more products added succesfully.");
                }
            }
            catch
            {
                //Console.WriteLine("There was a problem adding the products from products.xml");
            }
        }
    }
}