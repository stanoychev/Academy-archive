using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;
using OlympicGames.Olympics.Models;
using System.Collections.Generic;
using System;
using OlympicGames.Olympics.Enums;

namespace OlympicGames.Core.Factories
{
    public class OlympicsFactory : IOlympicsFactory
    {
        private static OlympicsFactory instance = new OlympicsFactory();

        private OlympicsFactory() { }

        public static OlympicsFactory Instance
        {
            get
            {
                return instance;
            }
        }//това било сингълтън, търси се връзката с методите долу. Конструкторът е private и класа
        //не може да създава обекти извън себе си

        public IOlympian CreateBoxer(string firstName, string lastName, string country, string category, int wins, int losses)
        {
            return new Boxer(firstName, lastName, country, category, wins, losses);
        }

        public IOlympian CreateSprinter(string firstName, string lastName, string country, IDictionary<string, double> records)
        {//опционалните параметри на спринтьора да оправя
            return new Sprinter(firstName, lastName, country, records);
        }
    }
}
