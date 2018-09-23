using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Online_Store.Core.Providers;
using Online_Store.Data;
using Online_Store.Models;

namespace Online_Store.Commands.ProductCommands
{
    public class ListProductsOnSaleCommand : Command, ICommand
    {
        public ListProductsOnSaleCommand(IStoreContext context, IWriter writer, IReader reader) : base(context, writer, reader)
        {
        }

        public override string Execute()
        {

            var productsOnSale = base.context.Products.Where(p => p.Sale.PriceReduction > 0).Select(p => p.ProductName);

            StringBuilder result = new StringBuilder();
            foreach (var product in productsOnSale)
            {
                result.Append(product);
            }

            return result.ToString();
        }
    }
}
