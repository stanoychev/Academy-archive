using System;
using System.Collections.Generic;

namespace Sensei.Models.Database
{
    public class Sensor
    {
        private ICollection<History> measurements;
        private ICollection<ApplicationUser> sharedWith;

        public Sensor()
        {
            this.measurements = new HashSet<History>();
            this.sharedWith = new HashSet<ApplicationUser>();
        }

        public int Id { get; set; }

        public string UserDefinedSensorName { get; set; }

        public string UserDefinedDescription { get; set; }

        public string UserDefinedMeasureType { get; set; }

        public bool IsPublic { get; set; }

        public double UserDefinedMinValue { get; set; }

        public double UserDefinedMaxValue { get; set; }

        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime? AddedOn { get; set; }

        public virtual ICollection<History> Measurements
        {
            get
            {
                return this.measurements;
            }
            set
            {
                this.measurements = value;
            }
        }

        public virtual ICollection<ApplicationUser> SharedWith
        {
            get
            {
                return this.sharedWith;
            }
            set
            {
                this.sharedWith = value;
            }
        }

        public int SensorTypeId { get; set; }

        public virtual SensorType SensorType { get; set; }

        public int LastValueId { get; set; }

        public virtual LastValue LastValue { get; set; }
    }
}