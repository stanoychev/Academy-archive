using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate
{
    public class SensorCurrentValues
    {
        public string TimeStamp { get; set; }

        public string Value { get; set; }
        //nai lesno e da se pazi kato string kakto API-to go podava, za6toto moje da e "15.7" kakto i "true"

        public string ValueType { get; set; }
    }
}
