using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;
using Sensei.Models;

namespace Sensei.ViewModels
{
    public class UserRoleViewModel
    {
        public ApplicationUser User { get; set; }

        public IList<string> Roles { get; set; }
    }
}