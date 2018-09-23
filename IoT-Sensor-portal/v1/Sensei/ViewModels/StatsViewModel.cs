using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sensei.ViewModels
{
    public class StatsViewModel
    {
        public int UsersCount { get; set; }
        public int SensorsCount { get; set; }
        public int PublicSensorsCount { get; set; }
        public int PrivateSensorsCount { get; set; }
    }
}