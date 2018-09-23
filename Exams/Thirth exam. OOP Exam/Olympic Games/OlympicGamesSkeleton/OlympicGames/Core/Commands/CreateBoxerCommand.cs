using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Factories;
using OlympicGames.Core.Providers;
using OlympicGames.Olympics.Models;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OlympicGames.Core.Commands
{
    public class CreateBoxerCommand : Command
    {   
        public CreateBoxerCommand(IList<string> commandLine) : base(commandLine)
        {
            if (commandLine.Count<=5)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }
            else
            {
                try
                {
                    int wins = int.Parse(commandLine[4]);
                    int losses = int.Parse(commandLine[5]);
                }
                catch (Exception)
                {
                    throw new ArgumentException(GlobalConstants.WinsLossesMustBeNumbers);
                }

                OlympicCommittee.Instance.Olympians.Add
                    (OlympicsFactory.Instance.CreateBoxer
                    (commandLine[0], commandLine[1], commandLine[2],
                    commandLine[3], int.Parse(commandLine[4]), int.Parse(commandLine[5])));
            }
        }
        
        public override string Execute()
        {
            var olympian = (Boxer)Committee.Olympians.Last();
            
            return string.Format("Created {0}\n{1}", olympian.OlympianType(),olympian.ToString());
        }
    }
}
