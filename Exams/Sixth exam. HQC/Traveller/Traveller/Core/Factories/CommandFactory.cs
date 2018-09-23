using Bytes2you.Validation;
using Ninject;
using System;
using Traveller.Commands.Contracts;

namespace Traveller.Core.Factories
{
    public class CommandFactory : ICommandFactory
    {
        private readonly IKernel kernel;

        public CommandFactory(IKernel kernel)
        {
            this.kernel = kernel ?? throw new ArgumentNullException("IoC container cannot be null.");
        }

        public ICommand CreateCommand(string commandName)
        {
            Guard.WhenArgument(commandName, "Command`s name cannot be null or empty.").IsNullOrEmpty().Throw();
            return this.kernel.Get<ICommand>(commandName);
        }
    }
}
