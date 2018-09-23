using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate
{
    public class PublicSensorInformation
    {
        public string SensorTag { get; set; } //demek tag-a
        
        public string MeasurementType { get; set; }
        
        //a kato e bool? mi 6e sa nqkvi default-ni ba li go
        public double MinValue { get; set; }
        public double MaxValue { get; set; }

        public string UserName { get; set; }
    }
}
