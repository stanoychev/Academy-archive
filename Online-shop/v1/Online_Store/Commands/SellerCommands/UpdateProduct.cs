using Bytes2you.Validation;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.SellerCommands
{
    public class UpdateProduct : Command, ICommand
    {
        private ILoggedUserProvider loggedUserProvider;

        public UpdateProduct(ILoggedUserProvider loggedUserProvider, IStoreContext context,
            IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();

            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute()
        {
            IList<string> parameters = TakeInput();

            int productId = int.Parse(parameters[0]);
            string property = parameters[1];
            string newValue = parameters[2];
            UpdateProductByID(productId, property, newValue);
            this.context.SaveChanges();

            return "Successfully updated Product!";
        }

        private void UpdateProductByID(int productId, string property, string newValue)
        {
            var product = this.context.Products.Single(p => p.Id == productId);

            switch (property.ToLower())
            {
                case "productname":
                    this.context.Products.Single(p => p.Id == productId).ProductName = newValue;
                    //this.context.Products.Attach(product);
                    //this.context.Entry(product).Property(x => x.ProductName).IsModified = true;

                    break;
                case "paynmentmethod":
                    switch (newValue.ToLower())
                    {
                        case "cash":
                            this.context.Products.Single(p => p.Id == productId).PaymentMethod = PaymentMethodEnum.Cash;
                            break;
                        case "mastercard":
                            this.context.Products.Single(p => p.Id == productId).PaymentMethod = PaymentMethodEnum.Cash;
                            break;
                        case "visa":
                            this.context.Products.Single(p => p.Id == productId).PaymentMethod = PaymentMethodEnum.Cash;
                            break;
                        case "vpay":
                            this.context.Products.Single(p => p.Id == productId).PaymentMethod = PaymentMethodEnum.Cash;
                            break;
                        case "kidney":
                            this.context.Products.Single(p => p.Id == productId).PaymentMethod = PaymentMethodEnum.Cash;
                            break;
                        default:
                            break;
                    }
                    break;
                case "price":
                    try
                    {
                        this.context.Products.Single(p => p.Id == productId).Price = decimal.Parse(newValue);
                    }
                    catch (Exception)
                    {
                        throw new Exception("Price must be a number");
                    }
                    break;
                default:
                    throw new Exception("Wrong Proprty!");
            }


        }

        private IList<string> TakeInput()
        {
            var result = new List<string>();
            int productId;

            try
            {
                productId = int.Parse(base.ReadOneLine("Enter product ID: "));
            }
            catch (Exception)
            {

                throw new Exception("productId Must be a number!");
            }

            if (productId > this.context.Products.Count())
            {
                throw new Exception("Wrong Product ID !");
            }
            result.Add(productId.ToString());

            //while (true)
            //{
            //    var property = base.ReadOneLine("What do you want to edit [press done if ready]?");
            //    if (property.ToLower().Equals("done"))
            //    {
            //        break;
            //    }

            //    if (property == "ProductName" || property == "Price"
            //        || property == "PaymentMethod" || property == "Instock"
            //        || property == "ShippingDetails")
            //    {
            //        result.Add(property);
            //        string newProperty = base.ReadOneLine($"{property}: ");
            //        UpdateProperty(productId, property, newProperty);
            //    }
            //    else
            //    {
            //        base.writer.WriteLine("Wrong Property ! [must be CamelCase]");
            //    }
            //}
            var propertyName = base.ReadOneLine("What do you want to edit: ").Trim();
            var newValue = base.ReadOneLine("Enter new value: ").Trim();

            result.Add(propertyName);
            result.Add(newValue);
            return result;
        }

    }
}
