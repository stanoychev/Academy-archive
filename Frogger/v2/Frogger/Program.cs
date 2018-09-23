using Frogger.Ninject;
using Ninject;
using System;
using Utils;

namespace Engine
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.SetWindowSize(GlobalConstants.screenWidth, GlobalConstants.screenHeight);
            Console.SetBufferSize(GlobalConstants.screenWidth, GlobalConstants.screenHeight);
            
            IKernel kernal = new StandardKernel(new GameModule());
            IEngine engine = kernal.Get<Engine>();

            engine.Load();
            engine.Run();
        }
    }
}