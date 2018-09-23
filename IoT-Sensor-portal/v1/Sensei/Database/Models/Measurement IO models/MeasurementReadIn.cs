using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sensei.Database.Models.Measurement_IO_models
{
    public class MeasurementReadIn
    {
        public string TimeStamp { get; set; }

        public string Value { get; set; }

        public string ValueType { get; set; }
    }
}