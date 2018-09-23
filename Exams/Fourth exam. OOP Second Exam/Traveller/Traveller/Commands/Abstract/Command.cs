using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Commands.Contracts;
using Traveller.Core.Contracts;

namespace Traveller.Commands.Abstract
{
    public abstract class Command : ICommand
    {
        private readonly ITravellerFactory factory;
        private readonly IEngine engine;

        public Command(ITravellerFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public ITravellerFactory Factory
        {
            get
            {
                return this.factory;
            }
        }

        public IEngine Engine
        {
            get
            {
                return this.engine;
            }
        }

        public virtual string Execute(IList<string> parameters)
        {
            return "";
        }
    }
}
