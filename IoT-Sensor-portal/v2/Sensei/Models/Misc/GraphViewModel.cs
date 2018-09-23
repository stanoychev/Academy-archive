using Sensei.Models.View;
using System.Collections.Generic;

namespace Sensei.Models.Misc
{
    public class GraphViewModel
    {
        public SensorDisplayData DisplayData { get; set; }

        public IList<string> JsonList { get; set; }
    }
}