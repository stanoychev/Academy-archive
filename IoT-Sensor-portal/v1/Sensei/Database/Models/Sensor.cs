using Sensei.Database.Models;
using Sensei.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Data.Models
{
    public class Sensor
    {
        private ICollection<Measurement> measurements;
        private ICollection<ApplicationUser> sharedWith;

        public Sensor()
        {
            this.measurements = new HashSet<Measurement>();
            this.sharedWith = new HashSet<ApplicationUser>();
        }

        public int SensorId { get; set; }
        
        [Display(Name = "Specify sensor`s name: ")]
        public string Name { get; set; }
        
        [Display(Name= "Sensor description:")]
        public string DescriptionGivenByTheUser { get; set; }

        //User defined measure type. Can defer from manufacture`s.
        [Display(Name = "Measurement type: ")]
        public string MeasurementType { get; set; }
        
        [Display(Name = "Public access (True/False): ")]
        public bool IsPublic { get; set; }

        [NotMapped]
        [Display(Name = "Operation Range: ")]
        public string OperatingRange { get; set; }

        [Display(Name = "Specify sensor minimal value: ")]
        public double MinValue { get; set; }

        [Display(Name = "Specify sensor maximum value: ")]
        public double MaxValue { get; set; }

        //public int ApplicationUserId { get; set; } currently not in use

        public virtual ApplicationUser ApplicationUser { get; set; }

        public DateTime? AddedOn { get; set; }
        
        public virtual ICollection<Measurement> Measurements
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

        //public int SensorTypeId { get; set; } currently not in use

        public virtual SensorType SensorType { get; set; }

        //public int LastValueId { get; set; } currently not in use

        public virtual LastValue LastValue { get; set; }
    }
}
