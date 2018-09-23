using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sensei.Models;

namespace Sensei.ViewModels
{
    public class UsersViewModel
    {
        public ApplicationUser User { get; set; }
        public string Role { get; set; }
    }
}