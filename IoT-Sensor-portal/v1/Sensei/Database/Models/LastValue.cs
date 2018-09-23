using Sensei.Data.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sensei.Database.Models
{
    public class LastValue
    {
        [Key, ForeignKey("Sensor")]
        public int SensorId { get; set; }

        public Sensor Sensor { get; set; }

        [Display(Name = "Unique Sensor ID, provided by ICB: ")]
        public string SensorIdICB { get; set; }

        [Required(ErrorMessage = "Poling interval should be larger than min polling interval.")]
        [Display(Name = "Specify polling interval in seconds: ")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only numbers.")]
        public int PollingInterval { get; set; }

        public string Value { get; set; }

        public DateTime? LastUpdatedOn { get; set; }
    }
}

// validations
/* magic variant 1:
 * custom model binder + if model state is valid else return to page
 * 
 * magic variant 2:
 * [Remote("",]
 * 
 * magic variant 3:
 * public class LastValue : IValidatableObject
 * */
