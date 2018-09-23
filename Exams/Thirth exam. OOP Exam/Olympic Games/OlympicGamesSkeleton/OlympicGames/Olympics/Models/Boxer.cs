using System;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Enums;
using OlympicGames.Utils;

namespace OlympicGames.Olympics.Models
{
    public class Boxer : Olympian, IBoxer
    {
        private BoxingCategory category;
        private int wins;
        private int losses;

        public Boxer(string firstName, string lastName, string country, string category, int wins, int losses)
            : base (firstName, lastName, country)
        {
            this.Category = (BoxingCategory)Enum.Parse(typeof(BoxingCategory), category, true);
            this.Wins = wins;
            this.Losses = losses;
        }
        
        public BoxingCategory Category
        {
            get
            {
                return this.category;
            }
            private set
            {
                //Validator.ValidateIfNull(value); в командата// май няма нужда, защото Parser-а го проверява и ако командата е в ред винаги идва непразен стринг
                //Validator.ValidateMinAndMaxNumber((int)value, 0, 4);
                //не правя проверка за тия категории, може да е проблем, но алтернативата е да изкара съобщение
                //категорията трябва да е между 1 или 4 или категорията трябва да е едно от "Flyweight, Featherweight, Lightweight, Middleweight, Heavyweight".

                this.category = value;
            }
        }
        public int Wins
        {
            get
            {
                return this.wins;
            }
            private set
            {
                Validator.ValidateMinAndMaxNumber(value, "Wins", 0, 100);
                this.wins = value;
            }
        }
        public int Losses
        {
            get
            {
                return this.losses;
            }
            private set
            {
                Validator.ValidateMinAndMaxNumber(value, "Losses", 0, 100);
                this.losses = value;
            }
        }

        public override string OlympianType()
        {
            return "Boxer";
        }

        public override string ToString()
        {
            return string.Format("{0}\nCategory: {1}\nWins: {2}\nLosses: {3}",
                base.ToString(),
                this.category,
                this.wins,
                this.losses);
        }
    }
}
