//using OlympicGames.Core.Contracts;
//using OlympicGames.Core.Factories;
//using OlympicGames.Core.Providers;
//using OlympicGames.Olympics.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OlympicGames.Core.Commands.Abstracts
//{
//    public abstract class CreateOlympianCommand : Command
//    {
//        private string firstName;
//        private string lastName;
//        private string country;
        
        

//        public CreateOlympianCommand(IList<string> commandLine) : base(commandLine)
//        {
//            this.firstName = commandLine[];
            
//        }

//        this.parser = CommandParser.Instance;

//        var command = this.parser.ParseCommand(commandLine);

//        //public Command(IList<string> commandLine)
//        //{
//        //    this.committee = OlympicCommittee.Instance;
//        //    this.factory = OlympicsFactory.Instance;
//        //    this.CommandParameters = commandLine;
//        //}

//        //ot boxera
//        //private string firstName;
//        //private string lastName;
//        //private string country;
//        //private string category;
//        //private int wins;
//        //private int losses;
//        //private IList<Boxer> boxers;

//        //public CreateBoxerCommand(IList<string> commandLine) : base(commandLine)
//        //{
//        //    if (commandLine[0] == "createboxer")
//        //    {
//        //        this.firstName = commandLine[1];
//        //        this.lastName = commandLine[2];
//        //        this.country = commandLine[3];
//        //        this.category = commandLine[4];
//        //        this.wins = int.Parse(commandLine[5]);
//        //        this.losses = int.Parse(commandLine[6]);
//        //    }
//        //}

//        //I boxer = new Boxer(firstName, lastName, country, category, wins, losses);



//        //public override string Execute()
//        //{
//        //    return "pesho"; //ili da go predade na naslednici boxer/sprinter
//        //}

//        public override string Execute()
//        {
//            throw new NotImplementedException();
//        }
//    }
//}
