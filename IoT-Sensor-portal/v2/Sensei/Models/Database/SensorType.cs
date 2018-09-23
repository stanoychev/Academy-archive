namespace Sensei.Models.Database
{
    public class SensorType
    {
        public int Id { get; set; }

        public string SensorIdICB { get; set; }

        public string Tag { get; set; }

        public string Description { get; set; }

        public int MinPollingIntervalInSeconds { get; set; }

        public string MeasureType { get; set; }

        public bool IsNumericValue { get; set; } //too big potential for usage. Else Description.Split().Contains("between"), but for many many demands it`s better to have just one ready IsNumericValue bit in the database
    }
}