using Ninject;
using Ninject.Modules;
using Traveller.Commands;
using Traveller.Commands.Contracts;
using Traveller.Commands.Creating;
using Traveller.Core;
using Traveller.Core.Contracts;
using Traveller.Core.Factories;
using Traveller.Core.Providers;

namespace Traveller.NinjectContainer
{
    public class TravellerModule : NinjectModule
    {
        public override void Load()
        {
            this.Bind<IReader>().To<Reader>().InSingletonScope();
            this.Bind<IWriter>().To<Writer>().InSingletonScope();
            this.Bind<IParser>().To<CommandParser>().InSingletonScope();
            this.Bind<IDatabase>().To<Database>().InSingletonScope();
            this.Bind<Core.Contracts.ITravellerFactory>().To<TravellerFactory>().InSingletonScope();
            this.Bind<ICommandFactory>().To<CommandFactory>().InSingletonScope();

            this.Bind<IEngine>().To<Engine>().InSingletonScope().Named("MainEngine");

            this.Bind<IEngine>().To<DecoratedEngine>()
                .InSingletonScope()
                .Named("DecoratedEngine")
                .WithConstructorArgument(this.Kernel.Get<IEngine>("MainEngine"));
            
            this.Bind<ICommand>().To<CreateAirplaneCommand>().Named("CreateAirplane".ToLower());
            this.Bind<ICommand>().To<CreateBusCommand>().Named("CreateBus".ToLower());
            this.Bind<ICommand>().To<CreateJourneyCommand>().Named("CreateJourney".ToLower());
            this.Bind<ICommand>().To<CreateTicketCommand>().Named("CreateTicket".ToLower());
            this.Bind<ICommand>().To<CreateTrainCommand>().Named("CreateTrain".ToLower());

            this.Bind<IListingCommands>().To<ListJourneysCommand>().Named("ListJourneysInternal".ToLower());
            this.Bind<IListingCommands>().To<ListTicketsCommand>().Named("ListTicketsInternal".ToLower());
            this.Bind<IListingCommands>().To<ListVehiclesCommand>().Named("ListVehiclesInternal".ToLower());

            this.Bind<ICommand>().To<ListCommandAdapter>()
                .Named("ListJourneys".ToLower())
                .WithConstructorArgument(this.Kernel.Get<IListingCommands>("ListJourneysInternal".ToLower()));
            this.Bind<ICommand>().To<ListCommandAdapter>()
                .Named("ListTickets".ToLower())
                .WithConstructorArgument(this.Kernel.Get<IListingCommands>("ListTicketsInternal".ToLower()));
            this.Bind<ICommand>().To<ListCommandAdapter>()
                .Named("ListVehicles".ToLower())
                .WithConstructorArgument(this.Kernel.Get<IListingCommands>("ListVehiclesInternal".ToLower()));
        }
    }
}
