namespace Sensei.Database.Models
{
    public class SensorType
    {
        public int Id { get; set; }

        public string SensorIdICB { get; set; }

        public string Tag { get; set; }
        
        public bool IsNumericValue { get; set; }

        public int MinPollingIntervalInSeconds { get; set; }

        //Specific sensors`s measure type.
        public string MeasureType { get; set; }
    }
}