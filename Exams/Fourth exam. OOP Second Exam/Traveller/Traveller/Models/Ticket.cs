using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Traveller.Models.Contracts;
using Traveller.Utils;

namespace Traveller.Models
{
    public class Ticket : ITicket
    {
        private decimal administrativeCosts;
        private IJourney journey;

        public Ticket(decimal administrativeCosts, IJourney journey)
        {
            this.AdministrativeCosts = administrativeCosts;
            this.Journey = journey;
        }

        public decimal AdministrativeCosts
        {
            get
            {
                return this.administrativeCosts;
            }
            set
            {
                //some general error can be implemented here
                this.administrativeCosts = value;
            }
        }

        public IJourney Journey
        {
            get
            {
                return this.journey;
            }
            set
            {
                this.journey = value;
            }
        }

        public decimal CalculatePrice()
        {
            return this.administrativeCosts + this.journey.CalculateTravelCosts();
        }

        public string TypeOfClass()
        {
            return "Ticket";
        }

        public override string ToString()
        {
            return string.Format("{0} ----\nDestination: {1}\nPrice: {2}",
                TypeOfClass(),
                this.journey.Destination,
                CalculatePrice());
        }
    }
}
