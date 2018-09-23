using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sensei.Data.Models.Intermediate
{
    public class SensorDisplayData
    {
        public int SensorId { get; set; }

        public string SensorIdICB { get; set; }

        public string UserName { get; set; }

        [Required]
        [Display(Name = "Sensor Name")]
        [StringLength(100, ErrorMessage = "The sensorName must be at least {2} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z0-9_]+$", ErrorMessage = "Only numbers, underscores and English letters are allowed.")]
        public string SensorName { get; set; }

        [Display(Name = "Sensor Tag")]
        public string SensorTag { get; set; }

        [Display(Name = "Measurement Type")]
        public string MeasurementType { get; set; }

        public string LastValue { get; set; }

        [Display(Name = "Min Value")]
        public double MinValue { get; set; }

        [Display(Name = "Max Value")]
        public double MaxValue { get; set; }

        [Display(Name = "Public")]
        public bool IsPublic { get; set; }

        [Display(Name = "Polling Interval")]
        public int PollingInterval { get; set; }

        [Display(Name = "Operating Range")]
        public string OperatingRange { get; set; }

        [Display(Name = "Added On")]
        public DateTime? AddedOn { get; set; }

        [Display(Name = "Description")]
        public string DescriptionGivenByTheUser { get; set; }
        
        //public virtual ICollection<Measurement> Measurements { get; set;} //za grafikata
    }
}
