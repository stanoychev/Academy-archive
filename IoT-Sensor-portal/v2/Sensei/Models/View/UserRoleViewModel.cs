using Sensei.Models.Database;
using System.Collections.Generic;

namespace Sensei.Models.View
{
    public class UserRoleViewModel
    {
        public ApplicationUser User { get; set; }

        public IList<string> Roles { get; set; }
    }
}