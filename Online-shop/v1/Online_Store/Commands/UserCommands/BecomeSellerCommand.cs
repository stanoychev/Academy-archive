using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System.Linq;

namespace Online_Store.Commands.UserCommands
{
    public class BecomeSellerCommand : Command, ICommand
    {
        private readonly IUserService userService;
        private readonly IModelFactory factory;
        private readonly ILoggedUserProvider loggedUserProvider;

        public BecomeSellerCommand(IModelFactory factory, IUserService userService, ILoggedUserProvider loggedUserProvider,
            IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(factory, "model factory").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();

            this.factory = factory;
            this.userService = userService;
            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute()
        {

            if (!this.userService.IsUserLogged())
            {
                return "You must Login First!";
            }

            if (this.context.Sellers.Any(i => i.UserId == this.loggedUserProvider.CurrentUserId))
            {
                return "You are already a Seller!";
            }

            var seller =  this.factory.CreateSeller();

            this.context.Users.SingleOrDefault(i => i.Id == this.loggedUserProvider.CurrentUserId).Seller = seller;
            this.context.SaveChanges();

            return $"Congrats, you can now Sell Products!";
        }

    }
}
