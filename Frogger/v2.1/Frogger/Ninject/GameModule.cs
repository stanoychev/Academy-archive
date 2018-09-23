using Engine;
using GameObjects;
using Ninject.Modules;

namespace Frogger.Ninject
{
    public class GameModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<ISettings>().To<Settings>().InSingletonScope();
            this.Bind<IFrog>().To<Frog>().InSingletonScope();
            this.Bind<IVehicle>().To<Vehicle>();
            this.Bind<IConsoleReader>().To<ConsoleReader>().InSingletonScope();
            this.Bind<IModelFactory>().To<ModelFactory>().InSingletonScope();
            this.Bind<IRowCollection>().To<RowCollection>().InSingletonScope();
            this.Bind<IConsoleWriter>().To<ConsoleWriter>().InSingletonScope();
            this.Bind<IEngine>().To<Engine.Engine>().InSingletonScope();
        }
    }
}
