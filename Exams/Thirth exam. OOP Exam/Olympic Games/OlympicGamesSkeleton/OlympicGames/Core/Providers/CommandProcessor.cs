using System;
using System.Collections.Generic;
using System.Linq;

using OlympicGames.Core.Contracts;

namespace OlympicGames.Core.Providers
{
    public class CommandProcessor : ICommandProcessor
    {
        private static CommandProcessor instance = new CommandProcessor();
        //това му е филда

        private CommandProcessor()
        {
            this.Commands = new List<ICommand>();
        }
        //конструкторът

        public static CommandProcessor Instance {
            get
            {
                return instance;
            }
        }
        //пропъртито

        public ICollection<ICommand> Commands { get; private set; }

        public void Add(ICommand command)
        {
            this.Commands.Add(command);
        }

        public void ProcessCommands()
        {
            foreach (var command in this.Commands)
            {
                var result = command.Execute();
                var normalizedOutput = this.NormalizeOutput(result);
                Console.WriteLine(normalizedOutput);
            }
        }

        public void ProcessSingleCommand(ICommand command)
        {
            var result = command.Execute();//ахаа е го Execute()-а, string result = command.Execute();
            var normalizedOutput = this.NormalizeOutput(result);
            Console.WriteLine(normalizedOutput);
        }

        private string NormalizeOutput(string commandOutput)
        {
            var list = commandOutput.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().Where(x => !string.IsNullOrWhiteSpace(x));

            return string.Join("\r\n", list);
        }
    }
}