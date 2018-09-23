using Frogger.Ninject;
using Ninject;

namespace Engine
{
    public class Program
    {
        static void Main(string[] args)
        {
            IKernel kernal = new StandardKernel(new GameModule());
            IEngine engine = kernal.Get<Engine>();
            engine.Run(kernal.Get<ModelFactory>(), kernal.Get<ConsoleReader>());
        }
    }
}