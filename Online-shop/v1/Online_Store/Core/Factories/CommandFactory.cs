using Bytes2you.Validation;
using Ninject;
using Online_Store.Commands;
using Online_Store.Core.Providers;
using Online_Store.Core.Services.User;

namespace Online_Store.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;
        private readonly IUserService userService;
        private readonly IWriter writer;

        public CommandFactory(IKernel kernel, IUserService userService, IWriter writer)
        {
            Guard.WhenArgument(kernel, "kernel").IsNull().Throw();
            Guard.WhenArgument(userService, "userService").IsNull().Throw();
            Guard.WhenArgument(writer, "writer").IsNull().Throw();

            this.kernel = kernel;
            this.userService = userService;
            this.writer = writer;
        }

        public ICommand CreateCommand(string commandName)
        {
            try
            {
                return this.kernel.Get<ICommand>(commandName);
            }
            catch
            {
                return this.kernel.Get<ICommand>("emptycommand");
            }
        }
    }
}