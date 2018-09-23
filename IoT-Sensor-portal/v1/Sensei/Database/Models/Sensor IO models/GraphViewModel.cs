using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Sensei.Data.Models.Intermediate;

namespace Sensei.ViewModels
{
    public class GraphViewModel
    {
        public SensorDisplayData DisplayData { get; set; }

        public IList<string> JsonList { get; set; }
    }
}