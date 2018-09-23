using OlympicGames.Olympics.Contracts;
using OlympicGames.Utils;

namespace OlympicGames.Olympics.Models
{
    public abstract class Olympian : IOlympian
        //validaciq tuk pravq po iziskvaniqta za olimpieca, v command sy6to prava kato za command
    {
        private string firstName;
        private string lastName;
        private string country;

        public Olympian(string firstName, string lastName, string country)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Country = country;
        }

        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            private set
            {
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, "First name", 2, 20);
                this.firstName = value;
            }
        }
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            private set
            {
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, "Last name", 2, 20);
                this.lastName = value;
            }
        }
        public string Country
        {
            get
            {
                return this.country;
            }
            private set //probvam private, za sega Compilatora ne gyrmi
            {
                Validator.ValidateIfNull(value);
                Validator.ValidateMinAndMaxLength(value, "Country", 3, 25);

                this.country = value;
            }
        }

        public abstract string OlympianType();

        public override string ToString()
        {
            return string.Format(
            "{0}: {1} {2} from {3}",
            this.OlympianType().ToUpper(),
            this.firstName,
            this.lastName,
            this.country);
        }
}
}
