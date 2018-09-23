using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Models.Database
{
    public class LastValue
    {
        [Key, ForeignKey("Sensor")]
        public int SensorId { get; set; }

        public Sensor Sensor { get; set; }

        public string SensorIdICB { get; set; }

        public int PollingInterval { get; set; }

        public string Value { get; set; }

        public DateTime? From { get; set; }
    }
}