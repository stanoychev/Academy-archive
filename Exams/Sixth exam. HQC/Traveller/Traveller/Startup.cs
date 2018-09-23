using Ninject;

using Traveller.Core;
using Traveller.NinjectContainer;

namespace Traveller
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            IKernel kernel = new StandardKernel(new TravellerModule());

            IEngine engine = kernel.Get<IEngine>("DecoratedEngine");

            engine.Start();
        }
    }
}