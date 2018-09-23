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
    public class CheckoutCardCommand : Command, ICommand
    {
        private readonly IModelFactory factory;
        private readonly ILoggedUserProvider loggedUserProvider;
        private readonly IUserService userService;

        public CheckoutCardCommand(ILoggedUserProvider loggedUserProvider, IUserService userService,
                    IModelFactory factory, IStoreContext context, IWriter writer, IReader reader)
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
            Console.WriteLine(this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
                           .Cart.Products.Count);

            var allProductsInCart = this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
                                                   .Cart.Products;
            if (allProductsInCart.Count == 0)
            {
                return "You don't have products in your cart!";
            }
            this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
                                                   .Cart.Products = new HashSet<Product>();
            //foreach (var pr in allProductsInCart)
            //{
            //    this.context.Products
            //        .Single(p => p.Id == pr.Id).Carts
            //        .Single(c => c.UserId == this.loggedUserProvider.CurrentUserId).Products.Remove(pr);
            //}

            var allProductNames = allProductsInCart.Select(p => p.ProductName);
            this.context.SaveChanges();

            Console.WriteLine(this.context.Users.Single(u => u.Id == this.loggedUserProvider.CurrentUserId)
                           .Cart.Products.Count);

            return $"Thank you for purchasing: \n---{string.Join("\n---", allProductNames)}";
        }
    }
}
