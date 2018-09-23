using System;

namespace Sensei.Data.Models
{
    public class Measurement
    {
        public int MeasurementId { get; set; }

        public string MeasurementType { get; set; }

        public DateTime? Date { get; set; }

        public string Value { get; set; }
        
        public int SensorId { get; set; }
        
        public virtual Sensor Sensor { get; set; }
    }
}
