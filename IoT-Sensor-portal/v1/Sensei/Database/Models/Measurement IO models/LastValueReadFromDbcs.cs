using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sensei.Database.Models.Measurement_IO_models
{
    public class LastValueReadFromDbcs
    {
        public int SensorId { get; set; }
        public string SensorIdICB { get; set; }
        public string Value { get; set; }
    }
}