using Bytes2you.Validation;
using Online_Store.Core.Factories;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Online_Store.Commands.UserCommands
{
    public class UserLoginCommand : Command, ICommand
    {
        private readonly IUserService userService;
        private readonly IModelFactory factory;
        private readonly ILoggedUserProvider loggedUserProvider;

        public UserLoginCommand(IModelFactory factory, IUserService userService, IStoreContext context,
            ILoggedUserProvider loggedUserProvider, IWriter writer, IReader reader)
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
            IList<string> parameters = TakeInput();
            if (this.loggedUserProvider.CurrentUserId != -1)
            {
                return "You are already logged in!";
            }
            string username = parameters[0];
            string password = parameters[1];

            userService.ValidateCredentials(username, password);

            this.loggedUserProvider.CurrentUserId = this.context.Users.Single(u => u.Username == username).Id;
            // Console.WriteLine(this.loggedUserProvider.CurrentUserId);

            return $"Successfully Logged in!";
        }

        private IList<string> TakeInput()
        {
            var username = base.ReadOneLine("Username: ");
            var password = base.ReadOneLine("Password: ");

            return new List<string>() { username, password };
        }
    }
}
