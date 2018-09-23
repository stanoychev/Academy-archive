using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using Online_Store.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.CartCommands
{
    public class AddToCartCommand : Command, ICommand
    {
        private readonly IModelFactory factory;
        private readonly ILoggedUserProvider loggedUserProvider;
        private readonly IUserService userService;


        public AddToCartCommand(ILoggedUserProvider loggedUserProvider, IUserService userService,
                    IModelFactory factory,IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();

            this.factory = factory;
            this.loggedUserProvider = loggedUserProvider;
            this.userService = userService;
        }

        public override string Execute()
        {
            if (!this.userService.IsUserLogged())
            {
                return "You must Login First!";
            }

            IList<string> parameters = TakeInput();

            return this.userService.AddToCart(parameters);
        }

        private IList<string> TakeInput()
        {
            var type = base.ReadOneLine("Choose by what to add Product: [id, name]: ");
            string id = null;
            string name = null;

            if (type.ToLower() == "id")
            {
                id = base.ReadOneLine("ProductId: ");
            }
            else if (type.ToLower() == "name")
            {
                name = base.ReadOneLine("Product Name: ");
            }
            else
            {
                this.writer.WriteLine("You didn't Enter 'id' or 'name'!");
            }

            return new List<string>() { id, name };
        }
    }
}
