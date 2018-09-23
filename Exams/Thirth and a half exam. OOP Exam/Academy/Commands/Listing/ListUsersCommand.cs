using System;
using System.Collections.Generic;
using Academy.Commands.Contracts;
using Academy.Core.Contracts;
using Academy.Models.Utils;

namespace Academy.Commands.Listing
{
    public class ListUsersCommand : ICommand
    {
        private readonly IAcademyFactory factory;
        private readonly IEngine engine;
        
        public ListUsersCommand(IAcademyFactory factory, IEngine engine)
        {
            this.factory = factory;
            this.engine = engine;
        }

        public string Execute(IList<string> parameters)//tova mi idva null ili empty
        {
            var trainers = engine.Trainers;
            var students = engine.Students;

            if (trainers.Count == 0 && students.Count == 0)
            {
                return GlobalConstants.NoUsers;
            }
            else if (trainers.Count == 0)
            {
                return Toolbox.PrintEnumerable(trainers);
            }
            else if (students.Count == 0)
            {
                return Toolbox.PrintEnumerable(students);
            }
            else
            {
                return string.Format("{0}\n{1}",
                    Toolbox.PrintEnumerable(trainers),
                    Toolbox.PrintEnumerable(students));
            }
        }

    }
}
