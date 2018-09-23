using Bytes2you.Validation;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.ProductCommands
{
    public class AddProductCommand : Command
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly ILoggedUserProvider loggedUserProvider;

        public AddProductCommand(IStoreContext context, IWriter writer, IReader  reader,
            IProductService productService, IUserService userService, ILoggedUserProvider loggedUserProvider)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(productService, "productService").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            this.productService = productService;
            this.userService = userService;
            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute()
        {
            if (!this.userService.IsUserLogged())
            {
                return "You must Login First!";
            }

            if (!this.context.Sellers.Any(x => x.UserId == loggedUserProvider.CurrentUserId))
            {
                return "Can`t add products if you are not a seller.";
            }

            IList<string> parameters = TakeInput();

            return this.productService.AddProduct(parameters);
        }
        
        private IList<string> TakeInput()
        {
            string productName = base.ReadOneLine("Enter product`s name: ").ToLower();
            if (base.context.Products.Any(x=>x.ProductName == productName))
            {
                throw new ArgumentException("Product already exists.");
            }
            string price = base.ReadOneLine("Enter price: ");
            while (true)
            {
                try
                {
                    decimal test = decimal.Parse(price);
                    if (test < 0)
                    {
                        throw new ArgumentException("Price cannot be negative number.");
                    }
                    break;
                }
                catch
                {
                    price = base.ReadOneLine("Invalid price, try again: ");
                }
            }
            string category = base.ReadOneLine("Enter category: ").ToLower();

            string[] paymentMethodsList = new string[] { "Cash", "VPay", "Visa", "MasterCard", "Kidney" };

            string paymentMethod = base.ReadOneLine(string.Format("{0}\n{1}\n",
            "Select payment method from list: ", string.Join(" ", paymentMethodsList))).ToLower();
            while (true)
            {
                try
                {   //малко е тъпа проверката после ще я оправям
                    if (!paymentMethodsList.Select(x=>x.ToLower()).Contains(paymentMethod.ToLower()))
                    {
                        throw new ArgumentException("Invalid payment method.");
                    }
                    break;
                }
                catch
                {
                    paymentMethod = base.ReadOneLine("Invalid payment method. Try again: ").ToLower();
                }
            }

            bool answerOnShippingDetails;
            string wannaShippingDetails = base.ReadOneLine("Will you provide shipping details [yes]/[no]? ").ToLower();
            while (true)
            {
                if (wannaShippingDetails=="yes")
                {
                    answerOnShippingDetails = true;
                    break;
                }
                else if (wannaShippingDetails == "no")
                {
                    answerOnShippingDetails = false;
                    break;
                }
                else
                {
                    wannaShippingDetails = base.ReadOneLine("Please provide an answer [yes] or [no]? ").ToLower();
                }
            }

            string shippingDetailsCost = "-1";
            string shippingDetailsDeliveryTIme = "-1";
            if (answerOnShippingDetails)
            {
                shippingDetailsCost = base.ReadOneLine("Select shipping cost: ");
                while (true)
                {
                    try
                    {
                        decimal test = decimal.Parse(shippingDetailsCost);
                        if (test < 0)
                        {
                            throw new ArgumentException("Price cannot be negative number.");
                        }
                        break;
                    }
                    catch
                    {
                        shippingDetailsCost = base.ReadOneLine("Invalid price, try again: ");
                    }
                }

                shippingDetailsDeliveryTIme = base.ReadOneLine("Select shipping delivery time in hours (integer): ");
                while (true)
                {
                    try
                    {
                        int test = int.Parse(shippingDetailsDeliveryTIme);
                        if (test < 0)
                        {
                            throw new ArgumentException("Delivery time cannot be negative number.");
                        }
                        break;
                    }
                    catch
                    {
                        shippingDetailsDeliveryTIme = base.ReadOneLine("Invalid delivery time, try again: ");
                    }
                }
            }

            bool answerOnSale;
            string saleBool = base.ReadOneLine("Is the product on sale [yes]/[no]? ").ToLower();
            while (true)
            {
                if (saleBool == "yes")
                {
                    answerOnSale = true;
                    break;
                }
                else if (saleBool == "no")
                {
                    answerOnSale = false;
                    break;
                }
                else
                {
                    saleBool = base.ReadOneLine("Please provide an answer [yes] or [no]? ").ToLower();
                }
            }

            string priceReduction = "-1";
            if (answerOnSale)
            {
                while (true)
                {
                    priceReduction = base.ReadOneLine("Enter price reduction in [%]: ");
                    while (true)
                    {
                        try
                        {
                            decimal test = decimal.Parse(priceReduction);
                            if (test < 0)
                            {
                                throw new ArgumentException("Reduction cannot be negative number.");
                            }
                            break;
                        }
                        catch
                        {
                            priceReduction = base.ReadOneLine("Please enter the price reduction in [%]: ");
                        }
                    }
                    break;

                    // saleBool = base.ReadOneLine("Please enter [yes] or [no]: ").ToLower();
                }
            }
            
            return new List<string>()
            {
                productName.ToLower(),
                price,
                category.ToLower(),
                paymentMethod,
                shippingDetailsCost,
                shippingDetailsDeliveryTIme,
                priceReduction
            };
        }
    }
}
//AUTO   int Id { get; set; }
//public string ProductName { get; set; }
//public decimal Price { get; set; }
//public virtual Category Categories { get; set; }
//AUTO   DateTime Date { get; set; }
//public PaymentMethodEnum PaymentMethod { get; set; }
//AUTO   bool Instock { get; set; }
//AUTO   virtual Seller Seller { get; set; }
//public virtual ShippingDetails ShippingDetails { get; set; }
//public virtual Feedback Feedback { get; set; }
//public virtual Sale Sale { get; set; }