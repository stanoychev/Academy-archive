using OlympicGames.Core.Commands.Abstracts;
using OlympicGames.Core.Contracts;
using OlympicGames.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OlympicGames.Core.Commands
{
    public class ListOlympiansCommand : Command, ICommand
    {
        private string key;
        private string order;
        
        public ListOlympiansCommand(IList<string> commandParameters)
            : base(commandParameters)
        {
            this.Key = "firstname";
            this.Order = "asc";

            if (commandParameters.Count == 1)
            {
                this.Key = commandParameters[0];
            }
            else if (commandParameters.Count == 2)
            {
                this.Key = commandParameters[0];
                this.Order = commandParameters[1];
            }
        }
        
        private string Key
        {
            get
            {
                return this.key;
            }
            set
            {
                this.key = value;
            }
        }

        private string Order
        {
            get
            {
                return this.order;
            }
            set
            {
                this.order = value;
            }
        }
        
        // Use it. It works!
        public override string Execute()
        {
            var stringBuilder = new StringBuilder();
            var sorted = this.Committee.Olympians.ToList();

            if (sorted.Count == 0)
            {
                return GlobalConstants.NoOlympiansAdded;
            }

            stringBuilder.AppendLine(string.Format(GlobalConstants.SortingTitle, this.key, this.order));

            if (this.order.ToLower().Trim() == "desc")
            {
                sorted = this.Committee.Olympians.OrderByDescending(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                }).ToList();
            }
            else
            {
                sorted = this.Committee.Olympians.OrderBy(x =>
                {
                    return x.GetType().GetProperties().FirstOrDefault(y => y.Name.ToLower() == this.key.ToLower()).GetValue(x, null);
                }).ToList();
            }

            foreach (var item in sorted)
            {
                stringBuilder.AppendLine(item.ToString());
            }

            return stringBuilder.ToString();
        }
    }
}
