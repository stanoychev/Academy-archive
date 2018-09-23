using Bytes2you.Validation;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;
using Online_Store.Data;

namespace Online_Store.Commands.UserCommands
{
    public class Logout : Command, ICommand
    {
        private readonly IUserService userService;
        private readonly ILoggedUserProvider loggedUserProvider;

        public Logout(IUserService userService, ILoggedUserProvider loggedUserProvider, IStoreContext context, IWriter writer, IReader reader)
            : base(context, writer, reader)
        {
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(loggedUserProvider, "loggedUserProvider").IsNull().Throw();

            this.userService = userService;
            this.loggedUserProvider = loggedUserProvider;
        }

        public override string Execute()
        {
            //add logout in user service
            this.loggedUserProvider.CurrentUserId = -1;

            return "Successfully loged out !";
        }
    }
}
