using Bytes2you.Validation;
using Online_Store.Core.Providers;
using Online_Store.Data;
using System.Linq;
using System.Text;

namespace Online_Store.Commands.SellerCommands
{
    public class ListAllProductsBySellerCommand : Command, ICommand
    {
        private ILoggedUserProvider loggedUserProvider;

        public ListAllProductsBySellerCommand(ILoggedUserProvider loggedUserProvider, IStoreContext context,
            IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();

            this.loggedUserProvider = loggedUserProvider;
        }

     
        public override string Execute()
        {
            var products = this.context.Sellers
                            .Single(i => i.UserId == this.loggedUserProvider.CurrentUserId).Products;
            if (products.Count == 0)
            {
                return "You aren't selling any products!";
            }

            StringBuilder result = new StringBuilder();
            foreach (var product in products)
            {
                result.Append(product.ToString());
            }

            return result.ToString();
        }
    }
}
