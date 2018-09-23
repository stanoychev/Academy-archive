using System.Collections.Generic;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Providers
{
    public class OlympicCommittee : IOlympicCommittee
    {
        private static readonly OlympicCommittee instance = new OlympicCommittee();

        private OlympicCommittee()
        {
            this.Olympians = new List<IOlympian>();
        }

        public ICollection<IOlympian> Olympians
        {
            get;
            private set;
        }

        public static OlympicCommittee Instance
        {
            get
            {
                return instance;
            }
        }
    }
}
