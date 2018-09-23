using System;
using System.Linq;
using System.Reflection;

using OlympicGames.Core.Contracts;
using OlympicGames.Olympics.Contracts;

namespace OlympicGames.Core.Providers
{
    public class CommandParser : ICommandParser
    {
        private static CommandParser instance = new CommandParser();

        private CommandParser() { }

        public static CommandParser Instance
        {
            get
            {
                return instance;
            }
        }

        public ICommand ParseCommand(string commandLine)
        {
            var lineParameters = commandLine.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var commandName = lineParameters[0]; //първата инструкция
            CheckForBaseClassImplementation(commandName); //проверява дали е валидна командата
            CheckForBaseClassTwoDerivedClasses(commandName); 
            var parameters = lineParameters.Skip(1); //презаписва инструкциите, изпускайки един брой елементи

            var typeInfo = FindCommand(commandName);
            //FindCommand връща някакъв commandType, след като е match-нало командата от Console.ReadLine() със съществуващо име на клас,
            //питанката е дали вика конкретния клас чрез първата инструкция или подава напред името на тази инструкция. По-скоро си мисля, 
            //че вика конкретния клас да се запали, като в командата е скипнато името на първата инструкция, което май означава,
            //List <string> command = new List<string>() { "Wladimir", "Klitschko", "Ukraine", "heavyweight", "64", "5"};
            var command = Activator.CreateInstance(typeInfo, parameters.ToList()) as ICommand;
            return command; //List <string> command = new List<string>() { "Wladimir", "Klitschko", "Ukraine", "heavyweight", "64", "5"};
        }

        private TypeInfo FindCommand(string commandName)
        {
            Assembly commandAssembly = Assembly.GetAssembly(typeof(ICommand));

            var commandType = commandAssembly.DefinedTypes
                .Where(x => x.ImplementedInterfaces.Any(y => y == typeof(ICommand)))//търси в имената на интерфейсите вероятно
                .Where(x => !x.IsAbstract)
                .SingleOrDefault(x => x.Name.ToLower() == (commandName.ToLower() + "command"));
            //джизъс крайст, името на класа "CreateBoxerCommand" => ToLower() = createboxercommand = "createboxer" инструкцията от Console.ReadLine() + "command"

            if (commandType == null)
            {
                throw new ArgumentException("No such command implemented! Consider implementing it before using!");
            }

            return commandType; //това връща някакъв commandType
        }

        #region DoNotTouch
        private void CheckForBaseClassImplementation(string commandName)
        {
            if (commandName == "checkbaseclass")
            {
                var assembly = Assembly.GetAssembly(typeof(IOlympian));
                var baseClass = assembly.DefinedTypes.Where(type => type.IsAbstract)
                    .Where(x => x.IsClass)
                    .FirstOrDefault(x => x.ImplementedInterfaces.Contains(typeof(IOlympian)));

                if (baseClass != null)
                {
                    throw new ArgumentException("BASE CLASS FOUND");
                }
            }
        }

        private void CheckForBaseClassTwoDerivedClasses(string commandName)
        {
            if (commandName == "checkbaseclassderived")
            {
                var assembly = Assembly.GetAssembly(typeof(IOlympian));
                var baseClass = assembly.DefinedTypes.Where(type => type.IsAbstract)
                    .Where(x => x.IsClass)
                    .FirstOrDefault(x => x.ImplementedInterfaces.Contains(typeof(IOlympian)));

                var baseClassesInheritans = assembly.DefinedTypes.Where(type => type.IsSubclassOf(baseClass)).Where(x => !x.IsAbstract);

                throw new ArgumentException(string.Format("BASE CLASS DERIVED COUNT: {0}", baseClassesInheritans.Count()));
            }
        }
        #endregion
    }
}
