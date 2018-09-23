using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate
{
    public class UsersOwnSensors
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CurrentValue { get; set; } //num of bool

        public bool IsPublic { get; set; }

        public ICollection<User> SharedWith { get; set; }
    }
}
