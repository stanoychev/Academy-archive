using System;

namespace Sensei.Models.Database
{
    public class History
    {
        public int Id { get; set; }

        public DateTime? From { get; set; }

        public DateTime? To { get; set; }

        public string Value { get; set; }

        public int SensorId { get; set; }

        public virtual Sensor Sensor { get; set; }
    }
}