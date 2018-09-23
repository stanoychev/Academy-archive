using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;
using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Core.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IStoreContext context;
        private readonly ILoggedUserProvider loggedUserProvider;
        private readonly IWriter writer;
        private readonly IModelFactory modelFactory;

        public ProductService(IStoreContext context, ILoggedUserProvider loggedUserProvider, IWriter writer,
            IModelFactory modelFactory)
        {
            Guard.WhenArgument(context, "context").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();
            Guard.WhenArgument(modelFactory, "modelFactory").IsNull().Throw();
            this.context = context;
            this.loggedUserProvider = loggedUserProvider;
            this.writer = writer;
            this.modelFactory = modelFactory;
        }

        public string AddProduct(IList<string> parameters)
        {
            string productName;
            decimal price;
            string category;
            PaymentMethodEnum paymentMethod;
            decimal shippingDetailsCost = 0;
            int shippingDetailsDeliveryTIme = 0;
            decimal priceReduction;
            bool shippingDetailsInUse = true;

            try
            {
                //validation
                productName = parameters[0].ToLower();
                if (this.context.Products.Any(x => x.ProductName == productName))
                {
                    return "Product already exists.";
                }
                price = decimal.Parse(parameters[1]);
                if (price < 0)
                {
                    throw new ArgumentException("Price cannot be negative.");
                }
                category = parameters[2].ToLower();
                paymentMethod = (PaymentMethodEnum)Enum.Parse(typeof(PaymentMethodEnum), parameters[3], true);
                if ((int)paymentMethod <= -1 || (int)paymentMethod >= 6)
                {
                    throw new ArgumentOutOfRangeException("Invalid payment method.");
                }

                if (parameters[4] != "-1" && parameters[5] != "-1")
                {
                    shippingDetailsCost = decimal.Parse(parameters[4]);
                    if (price < 0)
                    {
                        throw new ArgumentException("Shipping cost cannot be negative.");
                    }
                    shippingDetailsDeliveryTIme = int.Parse(parameters[5]);
                    if (price < 0)
                    {
                        throw new ArgumentException("Delivery time cannot be negative.");
                    }
                }
                else
                {
                    shippingDetailsInUse = false;
                }

                priceReduction = decimal.Parse(parameters[6]);
                if (price < 0)
                {
                    throw new ArgumentException("Price reduction cannot be negative.");
                }
            }
            catch
            {
                return "One or more parameters for the AddProduct command are invalid.";
            }

            Product product = this.modelFactory.CreateProduct();
            product.ProductName = productName;
            product.Price = price;
            product.Date = DateTime.Now;
            product.PaymentMethod = paymentMethod;
            product.Instock = true;
            product.SellerId = this.loggedUserProvider.CurrentUserId;

            if (this.context.Categories.Any(x => x.CategoryName == category))
            {
                product.Categories.Add(this.context.Categories.First(x => x.CategoryName == category));
            }
            else
            {
                Category newCategory = this.modelFactory.CreateCategory();
                newCategory.CategoryName = category;
                product.Categories.Add(newCategory);
            }

            if (shippingDetailsInUse)
            {
                ShippingDetails newShippingDetails = modelFactory.CreateShippingDetails();
                newShippingDetails.DeliveryTime = shippingDetailsDeliveryTIme;
                newShippingDetails.Cost = shippingDetailsCost;
                product.ShippingDetails = newShippingDetails;
            }

            if (priceReduction != -1)
            {
                Sale newSale = this.modelFactory.CreateSale();
                newSale.PriceReduction = priceReduction;
                product.Sale = newSale;
            }

            //this.context.Sellers.Single(s => s.UserId == this.loggedUserProvider.CurrentUserId)
            //  .Products.Add(product);

            context.Products.Add(product);
            context.SaveChanges();

            this.writer.CleanScrean();
            return "Product added succesfully.";
        }

        public string EditProduct(IList<string> parameters)
        {
            return "penka";
        }

        public string ListAllProducts()
        {
            IList<Product> productsToList = this.context.Products.ToList();

            if (!productsToList.Any())
            {
                return "No products!";
            }

            return string.Join("\n", productsToList);
        }

        public string ListFeedbacksFromProduct(string productName)
        {
            if (!this.context.Products.Any(x => x.ProductName == productName))
            {
                return "Product does not exist.";
            }
            try
            {
                IList<Feedback> feedbacksToList = this.context.Products.Single(x => x.ProductName == productName).Feedbacks.ToList();
                return string.Join("\n", feedbacksToList);
            }
            catch
            {
                return "Somehow more than one products with that name exist.";
            }
        }

        public string ListProductsByCategory(string categoryName)
        {
            if (!this.context.Categories.Any(x => x.CategoryName == categoryName))
            {
                return "No such category.";
            }

            IList<Product> productsToList = this.context.Categories
                            .Single(x => x.CategoryName == categoryName).Products.ToList();

            return String.Join("\n", productsToList);
        }

        public string RemoveProductWithId(string productId)
        {
            int id;
            try
            {
                id = int.Parse(productId);
            }
            catch (Exception ex)
            {
                return "ProductId Must be Int!";
            }

            if (!this.context.Products.Any(x => x.Id == id))
            {
                throw new ArgumentException("Product does not exist.");
            }

            Product product = this.modelFactory.CreateProduct();
            product.Id = id;

            try
            {
                this.context.Products.Attach(product);
                this.context.Products.Remove(product);
                this.context.SaveChanges();
                return "Product successfuly removed.";
            }
            catch
            {
                return "TOFIX: Product was not removed for some reason.";
            }
        }
    }
}
