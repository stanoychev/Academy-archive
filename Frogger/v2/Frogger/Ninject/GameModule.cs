using Engine;
using GameObjects;
using Ninject.Modules;

namespace Frogger.Ninject
{
    public class GameModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IFrog>().To<Frog>().InSingletonScope();
            this.Bind<IModelFactory>().To<ModelFactory>().InSingletonScope();
            this.Bind<IRowCollection>().To<RowCollection>().InSingletonScope();
            this.Bind<IConsoleKeyReader>().To<ConsoleKeyReader>().InSingletonScope();
            this.Bind<IConsoleWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IEngine>().To<Engine.Engine>().InSingletonScope();

        }
    }
}
