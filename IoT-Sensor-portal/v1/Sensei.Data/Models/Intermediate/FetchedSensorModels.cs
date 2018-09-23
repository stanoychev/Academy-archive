using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sensei.Data.Models.Intermediate
{
    public class FetchedSensorModels
    {
        public string SensorId { get; set; }

        public string Tag { get; set; }

        public string Description { get; set; }

        public int MinPollingIntervalInSeconds { get; set; }

        public string MeasureType { get; set; }
    }
}