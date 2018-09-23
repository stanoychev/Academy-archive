using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;

namespace OlympicGames.Core.Commands.Abstracts
{
    public abstract class Command : ICommand
    {
        private readonly OlympicCommittee committee;
        private readonly IOlympicsFactory factory;
        private IList<string> commandParameters;

        public Command(IList<string> commandLine)
        {
            this.committee = OlympicCommittee.Instance;
            this.factory = OlympicsFactory.Instance;
            this.CommandParameters = commandLine;
        }

        public IList<string> CommandParameters
        {
            get
            {
                return this.commandParameters;
            }
            protected set
            {
                this.commandParameters = value;
            }
        }

        public OlympicCommittee Committee
        {
            get
            {
                return this.committee;
            }
        }

        public IOlympicsFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public abstract string Execute();
    }
}
