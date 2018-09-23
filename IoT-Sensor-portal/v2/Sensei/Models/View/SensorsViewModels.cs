using Sensei.Models.API;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Sensei.Models.View
{
    public class RegisterNewSensor
    {
        //- - - - - - - for HTTP GET - - - - - - -
        public IEnumerable<APISensorType> AvailableSensors { get; set; }

        //- - - - - - - for HTTP POST - - - - - - -
        [Display(Name = "Unique Sensor ID, provided by ICB: ")]
        public string SensorIdICB { get; set; }

        [Display(Name = "Specify sensor`s name: ")]
        public string UserDefinedSensorName { get; set; }

        [Display(Name = "Measurement type: ")]
        public string UserDefinedMeasureType { get; set; }

        [Display(Name = "Public access (True/False): ")]
        public bool IsPublic { get; set; }

        [Required(ErrorMessage = "Poling interval should be larger than min polling interval.")]
        [RegularExpression(@"^[0-9]+$", ErrorMessage = "Only positive integer numbers.")]
        [Display(Name = "Specify polling interval in seconds: ")]
        public int PollingInterval { get; set; }

        [Display(Name = "Specify sensor minimal value: ")]
        public double UserDefinedMinValue { get; set; }

        [Display(Name = "Specify sensor maximum value: ")]
        public double UserDefinedMaxValue { get; set; }

        [Display(Name = "Sensor description:")]
        public string UserDefinedDescription { get; set; }

        [Display(Name = "Supported sensors: ")]
        public string Tag { get; set; }
    }

    public class ViewOwnSensorsModel
    {
        //- - - - - - - for HTTP GET - - - - - - -
        public IEnumerable<SensorDisplayData> OwnSensors { get; set; }

        //IEnumerable<{username}>
        public IEnumerable<string> RegisteredUsers { get; set; }

        //IDictionary<{SensorId}, IEnumerable<{username}>>
        public IDictionary<int, IEnumerable<string>> MySensorsAndWithWhoAreTheySharedWith { get; set; }

        public IEnumerable<SensorDisplayData> ListSharedWithMeSensors { get; set; }

        //- - - - - - - for HTTP POST - - - - - - -
        //IDictionary<{SensorId}, IEnumerable<{username}>>
        public IDictionary<int, IEnumerable<string>> UsersToShareMySensorsWith { get; set; }
    }

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