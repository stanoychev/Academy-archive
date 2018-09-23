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
    public class CreateSprinterCommand : Command
    {
        //да оправя валидации и default-ни стойности

        private readonly IDictionary<string, double> personalRecords;

        public CreateSprinterCommand(IList<string> commandLine) : base(commandLine)
        {
            if (commandLine.Count <= 2)
            {
                throw new ArgumentException(GlobalConstants.ParametersCountInvalid);
            }
            else
            {
                if (commandLine.Count != 3)
                {
                    Dictionary<string, double> temp = new Dictionary<string, double>();//
                    for (int i = 3; i <= commandLine.Count - 1; i++)
                    {
                        var key = commandLine[i].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[0]; //('/')[0];   
                        var value = double.Parse(commandLine[i].Split(new char[] { '/' }, StringSplitOptions.RemoveEmptyEntries)[1]); //('/')[0]);    //
                        temp.Add(key, value);
                    }
                    this.personalRecords = temp;//тъпо, но работи
                }
                OlympicCommittee.Instance.Olympians.Add
                    (OlympicsFactory.Instance.CreateSprinter
                    (commandLine[0], commandLine[1],
                    commandLine[2], this.personalRecords));
            }
        }
        
        public override string Execute()
        {
            var olympian = (Sprinter)Committee.Olympians.Last(); //работи

            return string.Format("Created {0}\n{1}", olympian.OlympianType(), olympian.ToString());
        }
    }
}
