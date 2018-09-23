using OlympicGames.Olympics.Contracts;
using System;
using System.Collections.Generic;
using OlympicGames.Utils;
using System.Text;
using System.Linq;

namespace OlympicGames.Olympics.Models
{
    public class Sprinter : Olympian, ISprinter
    {
        private IDictionary<string, double> personalRecords;

        public Sprinter(string firstName, string lastName, string country, IDictionary<string, double> personalRecords) : base(firstName, lastName, country)
        {
            this.PersonalRecords = personalRecords;
        }

        public IDictionary<string, double> PersonalRecords
        {
            get
            {
                return this.personalRecords;
            }
            private set
            {
                this.personalRecords = value;
            }
        }

        public override string OlympianType()
        {
            return "Sprinter";
        }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (this.personalRecords==null)
            {
                stringBuilder.Append(GlobalConstants.NoPersonalRecordsSet);
            }
            else
            {
                stringBuilder.Append(string.Format("{0}\n",GlobalConstants.PersonalRecords));
                foreach (KeyValuePair<string, double> element in this.personalRecords)
                {
                    stringBuilder.Append(string.Format("{0}m: {1}s\n", element.Key, element.Value));
                }
            }

            return string.Format("{0}\n{1}",
            base.ToString(),
            stringBuilder);
        }
    }
}
