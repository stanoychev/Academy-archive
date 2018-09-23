using Bytes2you.Validation;
using Online_Store.Core.ProductServices;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Linq;

namespace Online_Store.Commands.ProductCommands
{
    public class ListProductsByCategoryCommand : Command
    {
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly ILoggedUserProvider loggedUserProvider;

        public ListProductsByCategoryCommand(IStoreContext context, IWriter writer, IReader reader,
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

            string categoryToList = TakeInput();

            return this.productService.ListProductsByCategory(categoryToList);
        }

        private string TakeInput()
        {
            string categoryToList = base.ReadOneLine("For which category to list the products: ").ToLower();

            if (!base.context.Categories.Any(x=>x.CategoryName==categoryToList))
            {
                throw new ArgumentException("Category does not exist.");
            }

            return categoryToList;
        }
    }
}
